using AutoMapper;
using ECommerceDemoAPI.DTOs.Products;
using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.Interfaces;
using MediatR;

namespace ECommerceDemoAPI.UseCases.Products.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        private readonly CreateProductDTO _dto;

        public CreateProductCommand(CreateProductDTO dto)
        {
            _dto = dto;
        }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
        {
            private readonly IApplicationDBContext _context;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IApplicationDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Product>(request._dto);
                product.CreatedAt = DateTimeOffset.UtcNow;
                product.UpdatedAt = DateTimeOffset.UtcNow;

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}