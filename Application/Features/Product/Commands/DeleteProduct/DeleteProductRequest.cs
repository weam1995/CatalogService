using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands.DeleteProduct
{
    public record DeleteProductRequest: IRequest
    {
        public int Id { get; set; }
        public DeleteProductRequest(int id)
        {
            Id = id;
        }
    }
}
