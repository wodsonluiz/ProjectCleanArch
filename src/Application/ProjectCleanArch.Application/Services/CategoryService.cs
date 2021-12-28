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

        public async Task<CategoryDTO> AddAsync(CategoryDTO categoryDTO)
        {
            var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDTO);

            var result = await _mediator.Send(categoryCreateCommand);

            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categoryByIdQuery = new GetCategoryByIdQuery(id.Value);

            if (categoryByIdQuery is null) throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(categoryByIdQuery);

            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesQuery = new GetCategoriesQuery();

            if (categoriesQuery is null) throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(categoriesQuery);

            return _mapper.Map<IEnumerable<CategoryDTO>>(result);
        }

        public async Task RemoveAsync(int? id)
        {
            var categoryRemoveCommand = new CategoryRemoveCommand(id.Value);

            if (categoryRemoveCommand is null) throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(categoryRemoveCommand);
        }

        public async Task<CategoryDTO> UpdateAsync(CategoryDTO categoryDTO)
        {
            var categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryDTO);

            var result = await _mediator.Send(categoryUpdateCommand);

            return _mapper.Map<CategoryDTO>(result);
        }
    }
}
