using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.CreateCategory
{
    public record CreateCategoryRequest : IRequest<int>
    {
        public string? Name { get; init; } = string.Empty;
        public string? ImageURL { get; init; } = string.Empty;
        public int? ParentCategoryId { get; init; } = 0;
        public CreateCategoryRequest(string? name, string? imageURL, int parentCategoryId)
        {
            Name = name;
            ImageURL = imageURL;
            ParentCategoryId = parentCategoryId;
        }
    }
}
