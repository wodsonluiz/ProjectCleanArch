using MediatR;
using ProjectCleanArch.Application.Mediator.Categories.Commands;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Mediator.Categories.Handlers
{
    public class CategoryRemoveCommandHandler : IRequestHandler<CategoryRemoveCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryRemoveCommandHandler(ICategoryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Category> Handle(CategoryRemoveCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category is null)
            {
                throw new ApplicationException($"Error could not be found.");
            }
            else
            {
                return await _repository.RemoveAsync(category);
            }
        }
    }
}
