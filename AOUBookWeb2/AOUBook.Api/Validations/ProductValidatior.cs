using AOUBook.Api.Features.Commands.AddProduct;
using AOUBook.Models.ViewModels;
using FluentValidation;

namespace AOUBook.Api.Validatior
{
    public class ProductValidatior : AbstractValidator<AddProductCommand>
    {
        public ProductValidatior()
        {

            RuleFor(x => x.Title).NotEmpty().WithMessage("Product title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required aasadsf");
            RuleFor(x => x.ISBN).NotEmpty().WithMessage("ISBN is required");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required");
            RuleFor(x => x.ListPrice).NotEmpty().WithMessage("List Price is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Price).InclusiveBetween(1, 1000).WithMessage("Price must be between 1-1000");
            RuleFor(x => x.Price50).NotEmpty().WithMessage("Price50 is required");
            RuleFor(x => x.Price50).InclusiveBetween(1,1000).WithMessage("Price50 is AAA");
            RuleFor(x => x.Price100).NotEmpty().WithMessage("Price100 is required");
            RuleFor(x => x.Price100).InclusiveBetween(1, 1000).WithMessage("Price100 is BBB");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image is required");
            
            
        }

    }
}
