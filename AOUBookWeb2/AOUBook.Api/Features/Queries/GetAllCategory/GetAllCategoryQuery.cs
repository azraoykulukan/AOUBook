using AOUBook.Api.Models;
using MediatR;

namespace AOUBook.Api.Features.Queries.GetAllCategory
{
    public class GetAllCategoryQuery : IRequest<List<CategoryResponse>>
    {

    }
}
