using AOUBook.Api.Features.Queries.GetAllCategory;
using AOUBook.Api.Models;
using AOUBook.Api.Validatior;
using AOUBook.DataAccess.Repository.IRepository;
using AOUBook.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using MediatR;
using AOUBook.Api.Features.Queries.GetCategoryById;
using AOUBook.Api.Features.Commands.AddCategory;
using AOUBook.Api.Features.Commands.UpdateCategory;


namespace AOUBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AddCategoryCommand> _categoryValidator;
        private readonly IMediator _mediator;


        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<AddCategoryCommand> categoryValidator, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryValidator = categoryValidator;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Category>), StatusCodes.Status200OK)]
        public async Task <IActionResult> Get()
        {
            var mappedCategory = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(mappedCategory);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async Task <IActionResult> Get(int id)
        {
           var mappedCategory = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
            return Ok(mappedCategory);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async Task <IActionResult> Post([FromBody] AddCategoryCommand command)
        {
            var categoryResponse = new CategoryResponse();
            var validationResult = _categoryValidator.Validate(command);

            if (validationResult.IsValid)
            {
                categoryResponse = await _mediator.Send(command);
                _unitOfWork.Save();
                return Ok(categoryResponse);

            }
            else
            {
                return BadRequest(validationResult.Errors);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public async Task <IActionResult> Put(int id, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            var categoryResponse = new CategoryResponse();
            //var validationResult = _categoryValidator.Validate(command);

            categoryResponse = await _mediator.Send(command);
            _unitOfWork.Save();
            return Ok(categoryResponse);
            //}
            //else
            //{
            //    return BadRequest(ModelState);
            //}
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        public IActionResult Delete(int id) {
            var category = _unitOfWork.Category.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();

            var mappedCategory = _mapper.Map<CategoryResponse>(category);

            return Ok(mappedCategory);
        }

    }
}
