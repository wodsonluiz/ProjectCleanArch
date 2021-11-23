using MediatR;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Application.Mediator.Products.Commands
{
    public abstract class ProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
