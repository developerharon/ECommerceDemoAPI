using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.UseCases.Products.Commands;
using ECommerceDemoAPI.UseCases.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            if (products == null)
                return Ok(new List<Product>());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteProductByIdCommand(id)));
        }
    }
}