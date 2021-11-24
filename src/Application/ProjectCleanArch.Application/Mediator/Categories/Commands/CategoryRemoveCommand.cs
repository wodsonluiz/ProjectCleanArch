using MediatR;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Application.Mediator.Categories.Commands
{
    public class CategoryRemoveCommand : IRequest<Category>
    {
        public int Id { get; set; }
        public CategoryRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
