using ProjectCleanArch.Application.DTOs;
using System.Collections.Generic;

namespace ProjectCleanArch.Application.Test.Builders
{
    public class ProductDtoBuilder
    {
        private ProductDto _productDTO;
        private IEnumerable<ProductDto> _productsDTO;
        public ProductDtoBuilder() { }

        public ProductDtoBuilder BuildDefault()
        {
            _productDTO = new ProductDto()
            {
                Id = 1,
                Name = "Material default",
                Description = "Material default description",
                Image = "Image default",
                Price = 10m,
                Stock = 10
            };

            return this;
        }

        public ProductDtoBuilder SetName(string value)
        {
            _productDTO.Name = value;

            return this;
        }

        public ProductDtoBuilder SetDescription(string value)
        {
            _productDTO.Description = value;

            return this;
        }

        public ProductDtoBuilder SetImage(string value)
        {
            _productDTO.Image = value;

            return this;
        }

        public ProductDtoBuilder SetPrice(decimal value)
        {
            _productDTO.Price = value;

            return this;
        }

        public ProductDtoBuilder SetStock(int value)
        {
            _productDTO.Stock = value;

            return this;
        }

        public ProductDto Create() => _productDTO;

        public IEnumerable<ProductDto> CreateList()
        {
            _productsDTO = new List<ProductDto> { _productDTO };

            return _productsDTO;
        }
    }
}
