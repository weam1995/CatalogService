using Application.Contracts.Persistence;
using CatalogService.Application.Features.Category.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Features.Category.Queries.GetCategory
{
    public record GetCategoryByIdRequest : IRequest<CategoryDto>
    {
        public int Id { get; init; }
        public GetCategoryByIdRequest(int id)
        {
            Id = id;
        }
    }

}
