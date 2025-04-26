using HelpApp.Domain.Entities;
using HelpApp.Domain.Validation;
using FluentAssertions;
using Xunit;
using System;

namespace HelpApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName ="Should create a valid product with name, description, price, stock and image")]
        public void CreateProduct_WithValidParameters_ShouldCreateObject()
        {
            Action action = () => new Product("Product Name", "Product Description", 99.80m, 12, "/img/productImage.jpg");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Should create a valid product with id and all fields")]
        public void
        CreateProduct_WithIdAndValidParameters_ShouldCreateObject()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 280.00m, 17, "/img/productImage.jpg");

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos
        [Fact(DisplayName ="Should throw exception when product is created with negative id")]
        public void CreateProduct_WithNegativeId_ShouldThrowException()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 120.00m,
                65, "img/productImage.jpg");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Update Invalid Id value");
        }

        [Theory(DisplayName = "Should throw exception when product has null or empty name")]
        [InlineData(null)]
        [InlineData("")]
        public void CreateProduct_WithNullOrEmptyName_ShouldThrowException(string name)
        {
            Action action = () => new Product(name!, "Product Description", 120.00m, 65,
                "/img/productImage.jpg");
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Should throw exception when name has less than 3 characters.")]
        public void CreateProduct_WithShortName_ShouldThrowException()
        {
            Action action = () => new Product("Pr", "Product Descrption", 120.00m, 65, "/img/produtImage.jpg");

            action.Should().Throw<DomainExceptionValidation>
            ().WithMessage("Invalid name, too short, minimum 3 characters");

        }

        [Theory(DisplayName = "Should throw exception when description is null or empty")]
        [InlineData(null)]
        [InlineData("")]

        public void CreateProduct_WithNullOrEmptyDescription_ShouldThrowException(string description)
        {
            Action action = () => new Product("Product Name", description!, 120.00m, 65, "/img/productImage.jpg");

            action.Should().Throw<DomainExceptionValidation>
            ().WithMessage("Invalid description, name is required");
        }

        [Fact(DisplayName = "Should throw exception when description is too short")]
        public void CreateProduct_WithShortDescription_ShouldThrowException()
        {
            Action action = () => new Product("Product Name", "Prod", 120.00m, 65, "/img/productImage.jpg");

            action.Should().Throw<DomainExceptionValidation>
            ().WithMessage("Invalid description, too short, minimum 5 characters.");

        }

        [Fact(DisplayName = "Should throw exception when price is negative")]
        public void CreateProduct_WithNegativePrice_ShouldThrowException()
        {
            Action action = () => new Product("Product Name", "Product Description", -120.00m, 65, "/img/produtImage.jpg");

            action.Should().Throw<DomainExceptionValidation>
            ().WithMessage("Invalid price negative value.");
        }


        [Fact(DisplayName = "Should throw exception when stock is negative")]
        public void CreateProduct_WithNegativeStock_ShouldThrowException()
        {
            Action action = () => new Product("Product Name", "Product Description", 120.00m, -65, "/img/productImage.jpg");

            action.Should().Throw<DomainExceptionValidation>
                ().WithMessage("Invalid stock negative value.");
        }



        [Theory(DisplayName = "Should throw exception when image is null or empty")]
        [InlineData(null)]
        [InlineData("")]
        public void CreateProduct_WithNullOrEmptyImage_ShouldThrowException(string image)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 120.00m,
               65, image!);

            action.Should().Throw<DomainExceptionValidation>
            ().WithMessage("Invalid image address, image is required.");
        }

        [Fact(DisplayName = "Should throw exception when image length exceeds 250 characters")]
        public void CreateProduct_WithTooLongImageName_ShouldThrowException()
        {
            string longImageName = new string('p', 300);

            Action action = () => new Product("Product Name", "Product Description", 120.00m, 65, longImageName);

            action.Should().Throw<DomainExceptionValidation>
            ().WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        #endregion
    }
}
