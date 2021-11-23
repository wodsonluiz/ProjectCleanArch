using MediatR;
using ProjectCleanArch.Application.Mediator.Products.Commands;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Mediator.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _repository;
        public ProductCreateCommandHandler(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

            if (product is null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                product.CategoryId = request.CategoryId;

                return await _repository.CreateAsync(product);
            }
        }
    }
}
