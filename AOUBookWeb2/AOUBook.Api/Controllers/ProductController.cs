using AOUBook.Api.Features.Commands.AddProduct;
using AOUBook.Api.Features.Commands.DeleteProduct;
using AOUBook.Api.Features.Commands.UpdateProduct;
using AOUBook.Api.Features.Queries.GetAllProduct;
using AOUBook.Api.Features.Queries.GetProductById;
using AOUBook.Api.Models;
using AOUBook.Api.Validatior;
using AOUBook.DataAccess.Repository.IRepository;
using AOUBook.Models;
using AOUBook.Models.ViewModels;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using static AOUBook.Api.Models.ProductResponse;


namespace AOUBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<AddProductCommand> _productValidator;
        private readonly IMediator _mediator;


        public ProductController(IUnitOfWork unitOfWork, ILogger<ProductController> logger, IMapper mapper, IValidator<AddProductCommand> productValidator, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _productValidator = productValidator;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AOUBook.Models.Product>), StatusCodes.Status200OK)]
        public async Task <IActionResult> Get()
        {

            var mappedProduct = await _mediator.Send(new GetAllProductQuery());
            return Ok(mappedProduct);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AOUBook.Models.Product), StatusCodes.Status200OK)]
        public async Task <IActionResult> Get(int id)
        {
            var mappedProduct = await _mediator.Send(new GetProductByIdQuery { Id = id });

            return Ok(mappedProduct);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<AOUBook.Models.Product>), StatusCodes.Status200OK)]
        public async Task <IActionResult> Post([FromBody] AddProductCommand command)
        {
            var productResponse = new ProductResponse();
            var validationResult = _productValidator.Validate(command);

            if (validationResult.IsValid)
            {
                productResponse = await _mediator.Send(command);
                _unitOfWork.Save();
                return Ok(productResponse);
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }
        }
    
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<AOUBook.Models.Product>), StatusCodes.Status200OK)]
        public async Task <IActionResult> Put(int id, [FromBody] UpdateProductCommand command)
        {
            command.Id = id;
            var productResponse = new ProductResponse();
            //var validationResult = _productValidator.Validate(command);

            //if (validationResult.IsValid)
            //{
                productResponse = await _mediator.Send(command);
                _unitOfWork.Save();
                return Ok(productResponse);
            //}
            //else
            //{
            //    return BadRequest(validationResult.Errors);
            //}
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
           await _mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }



    }
}
