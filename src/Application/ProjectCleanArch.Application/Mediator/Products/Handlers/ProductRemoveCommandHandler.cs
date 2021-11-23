using MediatR;
using ProjectCleanArch.Application.Mediator.Products.Commands;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Mediator.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductRemoveCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product is null)
            {
                throw new ApplicationException($"Error could not be found.");
            }
            else
            {
                var result = await _repository.RemoveAsync(product);
                return result;
            }
        }
    }
}
