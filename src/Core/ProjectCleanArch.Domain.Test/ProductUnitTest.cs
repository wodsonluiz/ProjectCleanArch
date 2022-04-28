using FluentAssertions;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Validation;
using System;
using Xunit;

namespace ProjectCleanArch.Domain.Test
{
    public class ProductUnitTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Produc Description", 9.99m, 99, "product image");

            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectInvalidState()
        {
            Action action = () => new Product(-1, "Product Name", "Produc Description", 9.99m, 99, "product image");

            action.Should().Throw<DomainValidationException>().WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectInvalidStateSmallName()
        {
            Action action = () => new Product(1, "Pr", "Produc Description", 9.99m, 99, "product image");

            action.Should().Throw<DomainValidationException>().WithMessage("Invalid length to Name. Minimum 3 caracters");
        }

        [Fact]
        public void CreateProduct_WithLonglNameImage_ResultObjectInvalidState()
        {
            var nameImage = @"Name asdf asdf asdf asdf asdf asdf asdf adf asdf asdf asdf asdf asdf asdf adf asdf asdfa sdf 
                                asdf asdf asdf asdf asdf asdf asdf asd afsd fasdf asdf asdfadfadsf asdf asdf asdf asdf asdafsdf
                                asdfasdfasdfasd as dafsdf asd fasd fasdf asdf asdf asdf asdf asdf fasdf asdf asdf asdf";

            Action action = () => new Product(1, "Product name", "Produc Description", 9.99m, 99, nameImage);

            action.Should().Throw<DomainValidationException>().WithMessage("Invalid image name, too long, maximum 250 caracters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Produc Description", 9.99m, 99, null);

            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Produc Description", 9.99m, 99, null);

            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Produc Description", 9.99m, 99, "");

            action.Should().NotThrow<DomainValidationException>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_WithInvalidStockValue_ResultObjectValidState(int stock)
        {
            Action action = () => new Product(1, "Product Name", "Produc Description", 9.99m, stock, "Image name");

            action.Should().Throw<DomainValidationException>()
                .WithMessage("Invalid Stock value");
        }
    }
}
