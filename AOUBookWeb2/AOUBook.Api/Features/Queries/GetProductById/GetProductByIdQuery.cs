using AOUBook.Api.Models;
using MediatR;

namespace AOUBook.Api.Features.Queries.GetProductById
{ 
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public int Id { get; set; } 
    }
}
