using ECommerceDemoAPI.Entities;
using ECommerceDemoAPI.Interfaces;
using MediatR;

namespace ECommerceDemoAPI.UseCases.Products.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
        {
            private readonly IApplicationDBContext _context;

            public CreateProductCommandHandler(IApplicationDBContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    Name = request.Name,
                    Price = request.Price,
                    Quantity = request.Quantity,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}