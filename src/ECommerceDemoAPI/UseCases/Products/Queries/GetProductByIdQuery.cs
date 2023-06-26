using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product?>
    {
        private readonly Guid _productId;

        public GetProductByIdQuery(Guid productId)
        {
            _productId = productId;
        }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product?>
        {
            private readonly IApplicationDBContext _context;

            public GetProductByIdQueryHandler(IApplicationDBContext context)
            {
                _context = context;
            }

            public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.Products.Where(x => x.Id == request._productId).FirstOrDefaultAsync();
            }
        }
    }
}