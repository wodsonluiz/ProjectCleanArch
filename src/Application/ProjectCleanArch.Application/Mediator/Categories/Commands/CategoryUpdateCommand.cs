using MediatR;
using ProjectCleanArch.Domain.Entities;

namespace ProjectCleanArch.Application.Mediator.Categories.Commands
{
    public class CategoryUpdateCommand : IRequest<Category>
    {
        public int Id { get; set; }
    }
}
