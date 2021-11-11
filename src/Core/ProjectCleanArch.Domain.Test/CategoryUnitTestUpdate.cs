using FluentAssertions;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Validation;
using System;
using Xunit;

namespace ProjectCleanArch.Domain.Test
{
    public class CategoryUnitTestUpdate
    {
        [Fact]
        public void Update_WhitValidParameters_ResultObjectState()
        {
            //Arrange
            var categoy = new Category(1, "Category Name");

            //Act
            Action action = () => categoy.Update("Category Name update");

            //Assert
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void Update_WhitValidParameters_ResultObjectInvalidName()
        {
            //Arrange
            var categoy = new Category(1, "Category Name");

            //Act
            Action action = () => categoy.Update(null);

            //Assert
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact]
        public void Update_WhitEmpyName_DomainExceptionValidation()
        {
            //Arrange
            var categoy = new Category(1, "Category Name");

            //Act
            Action action = () => categoy.Update("");

            //Assert
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name is required");
        }
    }
}
