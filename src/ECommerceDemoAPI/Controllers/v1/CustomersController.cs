using ECommerceDemoAPI.DTOs.Customers;
using ECommerceDemoAPI.UseCases.Customers.Commands;
using ECommerceDemoAPI.UseCases.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDemoAPI.Controllers.v1
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());

            if (customers == null)
                return Ok(new List<GetCustomerDTO>());
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));

            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerDTO dto)
        {
            var customerId = await _mediator.Send(new CreateCustomerCommand(dto));
            return Ok(customerId);
        }

        [HttpPut("{id}")]
        public async  Task<IActionResult> Put(Guid id, UpdateCustomerDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var customerId = await _mediator.Send(new UpdateCustomerCommand(id, dto));
            return Ok(customerId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // TODO: Do we soft delete?
            var customerId = await _mediator.Send(new DeleteCustomerCommand(id));
            return Ok(customerId);
        }
    }
}