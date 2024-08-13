using AOUBook.Api.Features.Commands.AddProduct;
using AOUBook.Api.Features.Queries.GetProductById;
using AOUBook.Api.Models;
using AOUBook.DataAccess.Repository.IRepository;
using AOUBook.Models.ViewModels;
using AOUBook.Models;
using AutoMapper;
using MediatR;

namespace AOUBook.Api.Features.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetProductByIdHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IUnitOfWork unitOfWork, ILogger<GetProductByIdHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var mappedProduct = _mapper.Map<Product>(request);
            _unitOfWork.Product.Update(mappedProduct);
            _unitOfWork.Save();

            var returnResult = _mapper.Map<ProductResponse>(mappedProduct);
            return Task.FromResult(returnResult);
        }
    }
}