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

        public async Task<ProductDto> AddAsync(ProductDto productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            var product = await _mediator.Send(productCreateCommand);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> GetByIdAsync(int? id)
        {
            var productyByIdQuery = new GetProductByIdQuery(id.Value);

            var result = await _mediator.Send(productyByIdQuery);

            return _mapper.Map<ProductDto>(result);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            await _mediator.Send(productRemoveCommand);
        }

        public async Task<ProductDto> UpdateAsync(ProductDto productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);

            var result = await _mediator.Send(productUpdateCommand);

            return _mapper.Map<ProductDto>(result);
        }
    }
}
