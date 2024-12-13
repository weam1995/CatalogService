
using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetCategory;
using Application.Features.Category.Queries.ListCategories;
using Application.Features.Product.Commands.DeleteProduct;
using Application.Features.Product.Queries.ListProducts;
using Ardalis.GuardClauses;
using CatalogService.Application.Features.Category.Dtos;
using CatalogService.Application.Features.Product.Dtos;
using CatalogService.Domain.Entities;
using CatalogService.Persistence.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Authorize]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class CategoriesController(ISender sender) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(List<CategoryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListCategories()
        {
            var result = await sender.Send(new ListCategoriesRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await sender.Send(new GetCategoryByIdRequest(id));
            if (category is null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        [Authorize(Policy = "ManagerOnly")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Create(CreateCategoryRequest request)
        {
            var result = await sender.Send(request);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = "ManagerOnly")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest request)
        {
            var category = await sender.Send(new GetCategoryByIdRequest(request.Id));
            if (category.Equals(new CategoryDto())) return NotFound();
            await sender.Send(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "ManagerOnly")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await sender.Send(new DeleteCategoryRequest(id));
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
