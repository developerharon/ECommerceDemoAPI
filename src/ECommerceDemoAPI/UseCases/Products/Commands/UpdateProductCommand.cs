using AutoMapper;
using ECommerceDemoAPI.DTOs.Products;
using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Products.Commands
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        private readonly Guid _productId;
        private readonly UpdateProductDTO _dto;

        public UpdateProductCommand(Guid productId, UpdateProductDTO dto)
        {
            _productId = productId;
            _dto = dto;
        }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
        {
            private readonly IApplicationDBContext _context;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IApplicationDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(x => x.Id == request._productId).FirstOrDefaultAsync();

                if (product == null)
                    return default;

                _mapper.Map<UpdateProductDTO, Product>(request._dto, product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}