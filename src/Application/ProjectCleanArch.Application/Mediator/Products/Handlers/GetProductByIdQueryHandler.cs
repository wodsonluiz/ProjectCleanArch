using MediatR;
using ProjectCleanArch.Application.Mediator.Products.Queries;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Mediator.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
