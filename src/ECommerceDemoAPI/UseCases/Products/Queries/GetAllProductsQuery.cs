using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>?>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>?>
        {
            private readonly IApplicationDBContext _context;

            public GetAllProductsQueryHandler(IApplicationDBContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>?> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                return await _context.Products.ToListAsync();
            }
        }
    }
}