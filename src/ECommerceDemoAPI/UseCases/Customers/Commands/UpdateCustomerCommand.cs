using AutoMapper;
using ECommerceDemoAPI.DTOs.Customers;
using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<Guid>
    {
        private readonly Guid _customerId;
        private readonly UpdateCustomerDTO _dto;

        public UpdateCustomerCommand(Guid customerId, UpdateCustomerDTO dto)
        {
            _customerId = customerId;
            _dto = dto;
        }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Guid>
        {
            private readonly IApplicationDBContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateCustomerCommandHandler(IApplicationDBContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == request._customerId);

                if (customer == null)
                    return default;

                _mapper.Map(request._dto, customer);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return customer.Id;
            }
        }
    }
}