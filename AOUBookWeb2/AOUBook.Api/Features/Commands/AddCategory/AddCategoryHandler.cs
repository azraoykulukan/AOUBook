using AOUBook.Api.Models;
using AOUBook.DataAccess.Repository.IRepository;
using AOUBook.Models;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AOUBook.Api.Features.Commands.AddCategory
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand , CategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<CategoryResponse> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var mappedCategory = _mapper.Map<Category>(request);
            _unitOfWork.Category.Add(mappedCategory);
            _unitOfWork.Save();

            var returnResult = _mapper.Map<CategoryResponse>(mappedCategory);
            return Task.FromResult(returnResult);
        }
    }
}
