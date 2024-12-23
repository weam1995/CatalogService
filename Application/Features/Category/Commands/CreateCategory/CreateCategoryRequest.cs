using Ardalis.GuardClauses;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory
{
    public record CreateCategoryRequest : IRequest<int>
    {
        public string Name { get; init; }
        public string? ImageURL { get; init; }
        public int? ParentCategoryId { get; init; } = 0;
        public CreateCategoryRequest(string name, string? imageURL, int? parentCategoryId)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Name = name;
            ImageURL = imageURL;
            ParentCategoryId = parentCategoryId;
        }
    }
}
