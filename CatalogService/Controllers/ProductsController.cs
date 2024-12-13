
using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetCategory;
using Application.Features.Category.Queries.ListCategories;
using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Commands.DeleteProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Features.Product.Queries.GetProduct;
using Application.Features.Product.Queries.ListProducts;
using Ardalis.GuardClauses;
using CatalogService.Application.Features.Category.Dtos;
using CatalogService.Application.Features.Product.Dtos;
using CatalogService.Persistence.Contexts;
using Confluent.Kafka;
using KafkaClient.Producer;
using KafkaDemo.Events;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CatalogService.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class ProductsController(ISender sender) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ListProducts()
        {
            var result = await sender.Send(new ListProductsRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var category = await sender.Send(new GetProductRequestById(id));
            if (category is null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        [Authorize(Policy = "ManagerOnly")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            if (request is null) return BadRequest();
            var result = await sender.Send(request);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = "ManagerOnly")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
        {
            await sender.Send(request);
           

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "ManagerOnly")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await sender.Send(new DeleteProductRequest(id));
                return Ok();
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}