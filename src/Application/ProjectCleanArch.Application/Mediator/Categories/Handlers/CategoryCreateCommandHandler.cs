using MediatR;
using ProjectCleanArch.Application.Mediator.Categories.Commands;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Mediator.Categories.Handlers
{
    public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryCreateCommandHandler(ICategoryRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);

            if (category is null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _repository.CreateAsync(category);
            }
        }
    }
}
