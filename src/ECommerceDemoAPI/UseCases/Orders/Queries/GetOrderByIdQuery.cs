using AutoMapper;
using ECommerceDemoAPI.DTOs.Orders;
using ECommerceDemoAPI.Extensions;
using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Orders.Queries
{
    public class GetOrderByIdQuery : IRequest<GetOrderDTO?>
    {
        private readonly Guid _orderId;

        public GetOrderByIdQuery(Guid orderId)
        {
            _orderId = orderId;
        }

        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderDTO?>
        {
            private readonly IApplicationDBContext _context;
            private readonly IMapper _mapper;

            public GetOrderByIdQueryHandler(IApplicationDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetOrderDTO?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders
                    .Where(x => x.Id == request._orderId)
                    .Include(x => x.OrderItems)
                        .ThenInclude(x => x.Product)
                    .Include(x => x.Customer)
                    .FirstOrDefaultAsync();

                if (order == null)
                    return default;
                return order.MapOrderToGetOrderDTO(_mapper);
            }
        }
    }
}