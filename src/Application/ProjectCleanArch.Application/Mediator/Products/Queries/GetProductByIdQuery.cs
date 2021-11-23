using MediatR;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Application.Mediator.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
