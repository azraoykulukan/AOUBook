using AOUBook.Api.Models;
using MediatR;

namespace AOUBook.Api.Features.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryResponse>
    {
        public int Id { get; set; }
    }
}
