using AOUBook.Api.Features.Queries.GetAllProduct;
using AOUBook.Api.Models;
using AOUBook.DataAccess.Repository.IRepository;
using AutoMapper;
using MediatR;

namespace AOUBook.Api.Features.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetProductByIdHandler> _logger;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IUnitOfWork unitOfWork, ILogger<GetProductByIdHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }



        Task<ProductResponse> IRequestHandler<GetProductByIdQuery, ProductResponse>.Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = _unitOfWork.Product.Get(u => u.Id == request.Id, includeProperties: "Category");
            var mappedProduct = _mapper.Map<ProductResponse>(product);
            return Task.FromResult(mappedProduct);
        }
    }
}
