using AOUBook.Api.Models;
using AOUBook.DataAccess.Repository.IRepository;
using AOUBook.Models;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AOUBook.Api.Features.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        Task<CategoryResponse> IRequestHandler<GetCategoryByIdQuery, CategoryResponse>.Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = _unitOfWork.Category.Get(u => u.Id == request.Id);
            var mappedCategory = _mapper.Map<CategoryResponse>(category);
            return Task.FromResult(mappedCategory);
        }
    }
}
