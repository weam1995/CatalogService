using AutoMapper;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryRequestHandler(ICategoryRepository categoryRepository) : IRequestHandler<UpdateCategoryRequest>
    {
        public async Task Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var newCategory = new CatalogService.Domain.Entities.Category() { Id = request.Id, ImageURL = request.ImageURL, Name = request.Name, ParentCategoryId = request.ParentCategoryId };
            await categoryRepository.UpdateAsync(newCategory);
        }
    }
}
