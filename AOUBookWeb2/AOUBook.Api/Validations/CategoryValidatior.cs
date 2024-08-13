using AOUBook.Api.Features.Commands.AddCategory;
using AOUBook.Models;
using FluentValidation;

namespace AOUBook.Api.Validatior
{
    public class CategoryValidator : AbstractValidator<AddCategoryCommand>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category Name is required");
            RuleFor(x => x.DisplayOrder).NotEmpty().WithMessage("Display Order is required");
            RuleFor(x => x.DisplayOrder).InclusiveBetween(1, 100).WithMessage("Display Order must be between 1-100");
        }
    }
}
