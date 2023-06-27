using ECommerceDemoAPI.DTOs.Orders;
using ECommerceDemoAPI.UseCases.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDemoAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
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
    }
}