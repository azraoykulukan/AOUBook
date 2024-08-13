using AOUBook.Api.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AOUBook.Api.Features.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<CategoryResponse> 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
