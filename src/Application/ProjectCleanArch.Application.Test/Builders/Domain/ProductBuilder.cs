using ProjectCleanArch.Domain.Entities;
using System.Collections.Generic;

namespace ProjectCleanArch.Application.Test.Builders.Domain
{
    public class ProductBuilder
    {
        private Product _product;
        private IEnumerable<Product> _products;
        public ProductBuilder() { }

        public ProductBuilder BuildDefault()
        {
            _product = new Product(1, "Material default", "Material default description", 10m, 1, "image default");

            return this;
        }

        public Product Create() =>  _product;

        public IEnumerable<Product> CreateList()
        {
            _products = new List<Product>() { _product };

            return _products;
        }
    }
}
