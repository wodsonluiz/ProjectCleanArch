using AutoMapper;
using MediatR;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Application.Interfaces;
using ProjectCleanArch.Application.Mediator.Products.Commands;
using ProjectCleanArch.Application.Mediator.Products.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProductDTO> AddAsync(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            var product = await _mediator.Send(productCreateCommand);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productyByIdQuery = new GetProductByIdQuery(id.Value);

            if (productyByIdQuery is null) throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productyByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery is null) throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand is null) throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);

            await _mediator.Send(productUpdateCommand);
        }
    }
}
