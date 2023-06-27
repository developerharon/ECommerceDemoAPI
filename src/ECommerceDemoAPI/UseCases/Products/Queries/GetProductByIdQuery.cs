using AutoMapper;
using ECommerceDemoAPI.DTOs.Products;
using ECommerceDemoAPI.Extensions;
using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Products.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductDTO?>
    {
        private readonly Guid _productId;

        public GetProductByIdQuery(Guid productId)
        {
            _productId = productId;
        }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductDTO?>
        {
            private readonly IApplicationDBContext _context;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IApplicationDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetProductDTO?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(x => x.Id == request._productId).FirstOrDefaultAsync();
                return product?.MapProductToGetProductDTO(_mapper);
            }
        }
    }
}