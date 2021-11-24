using MediatR;
using ProjectCleanArch.Domain.Entities;
using System.Collections.Generic;

namespace ProjectCleanArch.Application.Mediator.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
