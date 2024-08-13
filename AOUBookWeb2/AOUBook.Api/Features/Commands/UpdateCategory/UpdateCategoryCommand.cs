using AOUBook.Api.Models;
using MediatR;

namespace AOUBook.Api.Features.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<CategoryResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
