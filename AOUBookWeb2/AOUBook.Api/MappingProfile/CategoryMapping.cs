using AOUBook.Api.Features.Commands.AddCategory;
using AOUBook.Api.Features.Commands.UpdateCategory;
using AOUBook.Api.Models;
using AOUBook.Models;
using AutoMapper;

namespace AOUBook.Api.MappingProfile
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<AddCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        }
    }
}
