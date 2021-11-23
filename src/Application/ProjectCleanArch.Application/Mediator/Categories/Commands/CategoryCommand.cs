using System.Collections.Generic;
using MediatR;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Application.Mediator.Categories.Commands
{
    public abstract class CategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}