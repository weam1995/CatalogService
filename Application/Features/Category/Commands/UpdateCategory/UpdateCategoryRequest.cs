using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory
{
    public record UpdateCategoryRequest : IRequest
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? ImageURL { get; init; }
        public int ParentCategoryId { get; init; }
    }
}
