using AOUBook.Api.Models;
using AOUBook.Models;
using MediatR;

namespace AOUBook.Api.Features.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<List<ProductResponse>>
    {

    }
}
