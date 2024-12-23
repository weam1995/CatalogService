using Application.Mapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.UpdateCategory
{
    public record UpdateCategoryRequest : IRequest
    {
        public int Id { get; init;}
        public string? Name { get; init;}
        public string? ImageURL { get; init; }
        public int ParentCategoryId {  get; init;}
    }
}
