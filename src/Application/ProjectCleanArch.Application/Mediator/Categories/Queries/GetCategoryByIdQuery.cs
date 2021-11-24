using MediatR;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Application.Mediator.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public int Id { get; set; }
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
