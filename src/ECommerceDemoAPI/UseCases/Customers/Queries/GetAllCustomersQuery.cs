using AutoMapper;
using ECommerceDemoAPI.DTOs.Customers;
using ECommerceDemoAPI.Extensions;
using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<GetCustomerDTO>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<GetCustomerDTO>>
        {
            private readonly IApplicationDBContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllCustomersQueryHandler(IApplicationDBContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetCustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
            {
                var customers = await _dbContext.Customers.ToListAsync();
                return customers.MapCustomerListToGetCustomerDTOList(_mapper);
            }
        }
    }
}