using ECommerceDemoAPI.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemoAPI.UseCases.Products.Commands
{
    public class DeleteProductByIdCommand : IRequest<Guid>
    {
        private readonly Guid _productId;

        public DeleteProductByIdCommand(Guid productId)
        {
            _productId = productId;
        }

        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Guid>
        {
            private readonly IApplicationDBContext _context;

            public DeleteProductByIdCommandHandler(IApplicationDBContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == request._productId).FirstOrDefaultAsync();

                if (product == null)
                    return default;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}