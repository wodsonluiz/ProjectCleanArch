using AutoMapper;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Application.Interfaces;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            await _productRepository.CreateAsync(product);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productAnCategory = await _productRepository.GetProductCategoryAsync(id);

            return _mapper.Map<ProductDTO>(productAnCategory);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task Remove(int? id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            await _productRepository.RemoveAsync(product);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            await _productRepository.UpdateAsync(product);
        }
    }
}
