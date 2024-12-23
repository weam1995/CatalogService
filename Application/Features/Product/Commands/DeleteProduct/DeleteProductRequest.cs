using MediatR;

namespace Application.Features.Product.Commands.DeleteProduct
{
    public record DeleteProductRequest : IRequest
    {
        public int Id { get; set; }
        public DeleteProductRequest(int id)
        {
            Id = id;
        }
    }
}
