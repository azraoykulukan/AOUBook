using AOUBook.Api.Features.Commands.AddProduct;
using AOUBook.Api.Features.Commands.UpdateProduct;
using AOUBook.Api.Models;
using AOUBook.Models;
using AutoMapper;

namespace AOUBook.Api.MappingProfile
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<AddProductCommand, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
        }
    }
}
