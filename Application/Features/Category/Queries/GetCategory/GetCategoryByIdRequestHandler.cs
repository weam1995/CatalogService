using AutoMapper;
using CatalogService.Application.Features.Category.Dtos;
using CatalogService.Domain.Interfaces.Persistence;
using MediatR;

namespace Application.Features.Category.Queries.GetCategory
{
    public class GetCategoryByIdRequestHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoryByIdRequest, CategoryDto>
    {
        public async Task<CategoryDto> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id);
            if (category is not null)
            {
                return mapper.Map<CategoryDto>(category);
            }
            return new CategoryDto();
        }
    }
}
