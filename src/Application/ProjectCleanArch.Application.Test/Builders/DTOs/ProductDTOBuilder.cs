using ProjectCleanArch.Application.DTOs;
using System.Collections.Generic;

namespace ProjectCleanArch.Application.Test.Builders
{
    public class ProductDTOBuilder
    {
        private ProductDTO _productDTO;
        private IEnumerable<ProductDTO> _productsDTO;
        public ProductDTOBuilder() { }

        public ProductDTOBuilder BuildDefault()
        {
            _productDTO = new ProductDTO()
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

        public ProductDTOBuilder SetName(string value)
        {
            _productDTO.Name = value;

            return this;
        }

        public ProductDTOBuilder SetDescription(string value)
        {
            _productDTO.Description = value;

            return this;
        }

        public ProductDTOBuilder SetImage(string value)
        {
            _productDTO.Image = value;

            return this;
        }

        public ProductDTOBuilder SetPrice(decimal value)
        {
            _productDTO.Price = value;

            return this;
        }

        public ProductDTOBuilder SetStock(int value)
        {
            _productDTO.Stock = value;

            return this;
        }

        public ProductDTO Create() => _productDTO;

        public IEnumerable<ProductDTO> CreateList()
        {
            _productsDTO = new List<ProductDTO> { _productDTO };

            return _productsDTO;
        }
    }
}
