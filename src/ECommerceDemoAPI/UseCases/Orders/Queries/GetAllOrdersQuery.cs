using AutoMapper;
using ECommerceDemoAPI.DTOs.Orders;
using ECommerceDemoAPI.Extensions;
using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<GetOrderDTO>>
    {
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<GetOrderDTO>>
        {
            private readonly IApplicationDBContext _context;
            private readonly IMapper _mapper;

            public GetAllOrdersQueryHandler(IApplicationDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetOrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
            {
                var orders = await _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product).ToListAsync();
                return orders.MapOrderListToGetOrderDTOList(_mapper);
            }
        }
    }
}