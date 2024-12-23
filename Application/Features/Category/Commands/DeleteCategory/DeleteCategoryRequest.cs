using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory
{
    public record DeleteCategoryRequest : IRequest
    {
        public int Id { get; set; }
        public DeleteCategoryRequest(int id)
        {
            Id = id;
        }
    }
}
