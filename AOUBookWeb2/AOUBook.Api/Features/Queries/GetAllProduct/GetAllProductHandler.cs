using AOUBook.Api.Controllers;
using AOUBook.Api.Features.Queries.GetAllProduct;
using AOUBook.Api.Models;
using AOUBook.DataAccess.Repository.IRepository;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AOUBook.Api.Features.Queries.GetAllProduct
{

    [ProducesResponseType(typeof(IEnumerable<AOUBook.Models.Product>), StatusCodes.Status200OK)]
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<ProductResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllProductHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllProductHandler(IUnitOfWork unitOfWork, ILogger<GetAllProductHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public Task<List<ProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<AOUBook.Models.Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            var mappedProduct = _mapper.Map<List<ProductResponse>>(productList);
            return Task.FromResult(mappedProduct);
        }
    }
}
