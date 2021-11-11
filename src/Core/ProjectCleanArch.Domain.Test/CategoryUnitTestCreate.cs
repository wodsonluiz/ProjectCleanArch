using FluentAssertions;
using ProjectCleanArch.Domain.Entities;
using ProjectCleanArch.Domain.Validation;
using System;
using Xunit;

namespace ProjectCleanArch.Domain.Test
{
    public class CategoryUnitTestCreate
    {
        [Fact]
        public void CreateCategory_WhitValidParameters_ResultObjectState()
        {
            //Arrange + Act
            Action action = () => new Category(1, "Category Name");

            //Assert
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_WhitValidParameters_ResultObjectInvalidName()
        {
            //Arrange + Act
            Action action = () => new Category(1, null);

            //Assert
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_WhitEmpyName_DomainExceptionValidation()
        {
            //Arrange + Act
            Action action = () => new Category(1, "");

            //Assert
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name is required");
        }

        [Fact]
        public void CreateCategory_WhitInvalideLengthName_DomainExceptionValidation()
        {
            //Arrange + Act
            Action action = () => new Category(1, "Ca");

            //Assert
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid length to Name. Minimum 3 caracters");
        }

        [Fact]
        public void CreateCategory_WhitInvalidId_DomainExceptionValidation()
        {
            //Arrange + Act
            Action action = () => new Category(-1, "Invalid Id Value");

            //Assert
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id Value");
        }
    }
}
