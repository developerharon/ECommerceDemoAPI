using AutoMapper;
using ECommerceDemoAPI.DTOs.Orders;
using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.Interfaces;
using MediatR;

namespace ECommerceDemoAPI.UseCases.Orders.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        private readonly CreateOrderDTO _dto;

        public CreateOrderCommand(CreateOrderDTO dto)
        {
            _dto = dto;
        }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
        {
            private readonly IApplicationDBContext _context;
            private readonly IMapper _mapper;

            public CreateOrderCommandHandler(IApplicationDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var order = _mapper.Map<Order>(request._dto);
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return order.Id;
            }
        }
    }
}
