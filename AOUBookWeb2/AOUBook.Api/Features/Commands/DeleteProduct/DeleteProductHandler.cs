using AOUBook.Api.Features.Queries.GetProductById;
using AOUBook.Api.Models;
using AOUBook.DataAccess.Repository.IRepository;
using AOUBook.Models;
using AutoMapper;
using MediatR;

namespace AOUBook.Api.Features.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetProductByIdHandler> _logger;
        private readonly IMapper _mapper;

        public DeleteProductHandler(IUnitOfWork unitOfWork, ILogger<GetProductByIdHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _unitOfWork.Product.Get(u => u.Id == request.Id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            
            return Task.CompletedTask;

        }
    }
}

