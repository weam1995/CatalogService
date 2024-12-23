
using CatalogService.Application.Features.Category.Dtos;
using MediatR;
namespace Application.Features.Category.Queries.GetCategory
{
    public record GetCategoryByIdRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }
        public GetCategoryByIdRequest(int id)
        {
            Id = id;
        }
    }

}
