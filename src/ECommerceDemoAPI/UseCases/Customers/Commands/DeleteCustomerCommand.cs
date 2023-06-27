using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<Guid>
    {
        private readonly Guid _customerId;

        public DeleteCustomerCommand(Guid customerId)
        {
            _customerId = customerId;
        }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Guid>
        {
            private readonly IApplicationDBContext _dbContext;

            public DeleteCustomerCommandHandler(IApplicationDBContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Guid> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == request._customerId);

                if (customer == null)
                    return default;

                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return customer.Id;
            }
        }
    }
}