using AOUBook.Api.Models;
using AOUBook.DataAccess.Repository.IRepository;
using AOUBook.Models;
using AutoMapper;
using MediatR;

namespace AOUBook.Api.Features.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<CategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var mappedCategory = _mapper.Map<Category>(request);
            _unitOfWork.Category.Update(mappedCategory);
            _unitOfWork.Save();

            var returnResult = _mapper.Map<CategoryResponse>(mappedCategory);
            return Task.FromResult(returnResult);
        }
    }
}
