using AOUBook.Api.Models;
using MediatR;

namespace AOUBook.Api.Features.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
