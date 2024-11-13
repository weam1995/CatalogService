using AutoMapper;
using CatalogService.Application.Features.Category.Dtos;
using CatalogService.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Queries.ListCategories
{
    public class ListCategoriesRequestHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<ListCategoriesRequest, List<CategoryDto>>
    {
        public async Task<List<CategoryDto>> Handle(ListCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetAllAsync();
            return mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
