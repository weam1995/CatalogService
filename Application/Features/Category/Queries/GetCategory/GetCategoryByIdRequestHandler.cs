using Application.Contracts.Persistence;
using AutoMapper;
using CatalogService.Application.Features.Category.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.GetCategory
{
    public class GetCategoryByIdRequestHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoryByIdRequest, CategoryDto>
    {
        public async Task<CategoryDto> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.Id);
            if(category is not null)
            {
                return mapper.Map<CategoryDto>(category);
            }
            return new CategoryDto();
        }
    }
}
