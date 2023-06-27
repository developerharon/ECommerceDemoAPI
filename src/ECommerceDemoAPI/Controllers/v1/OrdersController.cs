using ECommerceDemoAPI.DTOs.Orders;
using ECommerceDemoAPI.UseCases.Orders.Commands;
using ECommerceDemoAPI.UseCases.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDemoAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());

            if (orders == null)
                return Ok(new List<GetOrderDTO>());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));

            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderDTO orderDto)
        {
            var orderId = await _mediator.Send(new CreateOrderCommand(orderDto));
            return Ok(orderId);
        }
    }
}