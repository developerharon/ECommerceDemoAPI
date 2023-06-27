using AutoMapper;
using ECommerceDemoAPI.DTOs.Customers;
using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.Interfaces;
using MediatR;

namespace ECommerceDemoAPI.UseCases.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        private readonly CreateCustomerDTO _dto;

        public CreateCustomerCommand(CreateCustomerDTO dto)
        {
            _dto = dto;
        }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
        {
            private readonly IApplicationDBContext _dbContext;
            private readonly IMapper _mapper;

            public CreateCustomerCommandHandler(IApplicationDBContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = _mapper.Map<Customer>(request._dto);
                _dbContext.Customers.Add(customer);
                await _dbContext.SaveChangesAsync();
                return customer.Id;
            }
        }
    }
}