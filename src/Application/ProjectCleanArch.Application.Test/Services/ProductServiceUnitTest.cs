using FluentAssertions;
using MediatR;
using Moq;
using Moq.AutoMock;
using ProjectCleanArch.Application.DTOs;
using ProjectCleanArch.Application.Mediator.Products.Commands;
using ProjectCleanArch.Application.Mediator.Products.Queries;
using ProjectCleanArch.Application.Services;
using ProjectCleanArch.Application.Test.Builders;
using ProjectCleanArch.Application.Test.Builders.Domain;
using ProjectCleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProjectCleanArch.Application.Test.Services
{
    public class ProductServiceUnitTest
    {
        [Fact]
        public void ProductService_RequestAllProducts_ResultListOfProducts()
        {
            //Arrange
            var mocker = new AutoMocker();

            var productsDTO = new ProductDTOBuilder()
                .BuildDefault()
                .CreateList();

            var products = new ProductBuilder().BuildDefault().CreateList();

            mocker.Setup<IMediator, Task<IEnumerable<Product>>>(x => x.Send(It.IsAny<GetProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(products);

            var service = mocker.CreateInstance<ProductService>();

            //Act
            Action action = () => service.GetProductsAsync().ConfigureAwait(false);

            //Assert
            action.Should().NotThrow();
            mocker.VerifyAll();
        }

        [Fact]
        public void ProductService_RequestById_ResultProduct()
        {
            //Arrange
            var mocker = new AutoMocker();

            var productDTO = new ProductDTOBuilder()
                .BuildDefault()
                .Create();

            var product = new ProductBuilder()
                .BuildDefault()
                .Create();

            mocker.Setup<IMediator, Task<Product>>(x => x.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(product);

            var service = mocker.CreateInstance<ProductService>();

            //Act
            Action action = () => service.GetByIdAsync(1).ConfigureAwait(false);

            //Assert
            action.Should().NotThrow();
            mocker.VerifyAll();
        }

        [Fact]
        public void ProducService_CreateProduct_ResultProduct()
        {
            //Arrange
            var mocker = new AutoMocker();

            var productDTO = new ProductDTOBuilder()
                .BuildDefault()
                .Create();

            var product = new ProductBuilder()
                .BuildDefault()
                .Create();

            mocker.Setup<IMediator, Task<Product>>(x => x.Send(It.IsAny<ProductCreateCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(product);

            var service = mocker.CreateInstance<ProductService>();

            //Act
            Action action = () => service.AddAsync(productDTO).ConfigureAwait(false);

            //Assert
            action.Should().NotThrow();
            mocker.VerifyAll();
        }
    }
}
