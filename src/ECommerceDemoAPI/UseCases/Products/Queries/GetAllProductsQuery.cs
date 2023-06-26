using AutoMapper;
using ECommerceDemoAPI.DTOs.Products;
using ECommerceDemoAPI.Extensions;
using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<GetProductDTO>?>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetProductDTO>?>
        {
            private readonly IApplicationDBContext _context;
            private readonly IMapper _mapper;

            public GetAllProductsQueryHandler(IApplicationDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetProductDTO>?> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync();
                return products.MapProductListToGetProductDTOList(_mapper);
            }
        }
    }
}