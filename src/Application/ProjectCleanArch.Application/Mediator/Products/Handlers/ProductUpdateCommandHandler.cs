using MediatR;
using ProjectCleanArch.Application.Mediator.Products.Commands;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Mediator.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductUpdateCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product is null)
            {
                throw new ApplicationException($"Error could not be found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

                return await _repository.UpdateAsync(product);
            }
        }
    }
}
