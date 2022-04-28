using AutoMapper;
using MediatR;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Application.Interfaces;
using ProjectCleanArch.Application.Mediator.Categories.Commands;
using ProjectCleanArch.Application.Mediator.Categories.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryService(IMapper mapper, IMediator meditor)
        {
            _mediator = meditor ?? throw new ArgumentNullException(nameof(meditor));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDTO)
        {
            var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDTO);

            var result = await _mediator.Send(categoryCreateCommand);

            return _mapper.Map<CategoryDto>(result);
        }

        public async Task<CategoryDto> GetByIdAsync(int? id)
        {
            var categoryByIdQuery = new GetCategoryByIdQuery(id.Value);

            var result = await _mediator.Send(categoryByIdQuery);

            return _mapper.Map<CategoryDto>(result);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categoriesQuery = new GetCategoriesQuery();

            var result = await _mediator.Send(categoriesQuery);

            return _mapper.Map<IEnumerable<CategoryDto>>(result);
        }

        public async Task RemoveAsync(int? id)
        {
            var categoryRemoveCommand = new CategoryRemoveCommand(id.Value);

            await _mediator.Send(categoryRemoveCommand);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto categoryDTO)
        {
            var categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryDTO);

            var result = await _mediator.Send(categoryUpdateCommand);

            return _mapper.Map<CategoryDto>(result);
        }
    }
}
