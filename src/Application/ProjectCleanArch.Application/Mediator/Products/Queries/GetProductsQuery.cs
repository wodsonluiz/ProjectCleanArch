using MediatR;
using ProjectCleanArch.Domain.Entities;
using System.Collections.Generic;

namespace ProjectCleanArch.Application.Mediator.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
