using AutoMapper;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces.Persistence;
using Confluent.Kafka;
using KafkaClient.Producer;
using KafkaDemo.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductRequestHandler(IProductRepository productRepository, IMapper mapper, ICatalogDBContext dbContext) : IRequestHandler<UpdateProductRequest>
    {
        public async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<CatalogService.Domain.Entities.Product>(request);

            await productRepository.UpdateAsync(product);
            var producer = new KafkaProducer().Producer;
            var productChangedEvent = new ProductChangedEvent()
            {
                Id = request.Id,
                Name = request.Name,
                ImageURL = request.ImageURL,
                Price = request.Price,
            };

                using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                // Save product to database
                dbContext.Products.Add(product);
                await dbContext.SaveChangesAsync();

                // Create outbox message
                var outboxMessage = new OutboxMessage(DateTime.Now, "ProductChange", JsonConvert.SerializeObject(productChangedEvent));
                dbContext.OutboxMessages.Add(outboxMessage);
                await dbContext.SaveChangesAsync();

                // Commit both changes
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw; // Re-throw the exception to handle it further up the chain
            }


            await producer.ProduceAsync("productChange-topic", new Message<string, string>
            {
                Key = request.Id.ToString(),
                Value = JsonConvert.SerializeObject(productChangedEvent)
            });

        }
    }
}
