using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Products.Commands
{
    public class UpdateProductCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
        {
            private readonly IApplicationDBContext _context;

            public UpdateProductCommandHandler(IApplicationDBContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

                if (product == null)
                    return default;

                product.Name = request.Name;
                product.Price = request.Price;
                product.Quantity = request.Quantity;
                //_context.Products.Update(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}