using AutoMapper;
using ECommerceDemoAPI.DTOs.Customers;
using ECommerceDemoAPI.Extensions;
using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerDTO?>
    {
        private readonly Guid _customerId;

        public GetCustomerByIdQuery(Guid customerId)
        {
            _customerId = customerId;
        }

        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerDTO?>
        {
            private readonly IApplicationDBContext _dbContext;
            private readonly IMapper _mapper;

            public GetCustomerByIdQueryHandler(IApplicationDBContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<GetCustomerDTO?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == request._customerId);
                return customer?.MapCustomerToGetCustomerDTO(_mapper);
            }
        }
    }
}