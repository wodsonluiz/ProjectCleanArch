using MediatR;
using ProjectCleanArch.Application.Mediator.Categories.Commands;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Mediator.Categories.Handlers
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryUpdateCommandHandler(ICategoryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category is null)
            {
                throw new ApplicationException($"Error could not be found.");
            }
            else
            {
                category.Update(request.Name);

                return await _repository.UpdateAsync(category);
            }
        }
    }
}
