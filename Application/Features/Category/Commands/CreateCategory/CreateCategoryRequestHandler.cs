using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryRequestHandler(ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryRequest, int>
    {
        public async Task<int> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var newCategory = new CatalogService.Domain.Entities.Category()
            {
                Name = request.Name,
                ImageURL = request.ImageURL,
                ParentCategoryId = request.ParentCategoryId
            };
            return await categoryRepository.CreateAsync(newCategory);
        }
    }
}
