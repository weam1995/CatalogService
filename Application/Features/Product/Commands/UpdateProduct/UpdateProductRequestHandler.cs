using AutoMapper;
using CatalogService.Domain.Interfaces.Persistence;
using Confluent.Kafka;
using KafkaClient.Producer;
using KafkaDemo.Events;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Confluent.Kafka.ConfigPropertyNames;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductRequestHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<UpdateProductRequest>
    {
        private static async Task SendMessageToDeadLetterQueue(IProducer<string,string> producer, Message<string,string> kafkaMessage)
        {
            await producer.ProduceAsync("DeadLetterQueue", kafkaMessage);
        }
        public async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<CatalogService.Domain.Entities.Product>(request);
            var kafkaProducer = new KafkaProducer();
            var producer = kafkaProducer.Producer;
            var retryCount = kafkaProducer.producerConfig.MessageSendMaxRetries;
            var productChangedEvent = new ProductChangedEvent()
            {
                Id = request.Id,
                Name = request.Name,
                ImageURL = request.ImageURL,
                Price = request.Price,
            };
            await productRepository.UpdateAsync(product);
            try
            {
                var retries = 0;
                bool messageConsumed = false;
                while (retries< retryCount && !messageConsumed)
                {
                    try
                    {
                        await producer.ProduceAsync("productChange-topic", new Message<string, string>
                        {
                            Key = request.Id.ToString(),
                            Value = JsonConvert.SerializeObject(productChangedEvent)
                        }, cancellationToken);
                        messageConsumed = true;
                        break;
                    }
                    catch(Exception)
                    {
                        retries++;
                    }
                }
                await SendMessageToDeadLetterQueue(producer, new Message<string, string>
                {
                    Key = request.Id.ToString(),
                    Value = JsonConvert.SerializeObject(productChangedEvent)
                });

            }
            catch (ProduceException<string,string>)
            {
                await SendMessageToDeadLetterQueue(producer, new Message<string, string>
                {
                    Key = request.Id.ToString(),
                    Value = JsonConvert.SerializeObject(productChangedEvent)
                });
            }

        }
    }
}
