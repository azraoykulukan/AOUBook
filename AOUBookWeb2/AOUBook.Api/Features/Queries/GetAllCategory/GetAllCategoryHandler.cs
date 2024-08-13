using AOUBook.Api.Models;
using AOUBook.DataAccess.Repository.IRepository;
using AOUBook.Models;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AOUBook.Api.Features.Queries.GetAllCategory
{

    [ProducesResponseType(typeof(IEnumerable<Category>), StatusCodes.Status200OK)]
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<CategoryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryList = _unitOfWork.Category.GetAll();
            var mappedCategory = _mapper.Map<List<CategoryResponse>>(categoryList);
            return Task.FromResult(mappedCategory);
        }
    }
}
