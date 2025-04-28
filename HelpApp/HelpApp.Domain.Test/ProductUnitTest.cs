using HelpApp.Domain.Entities;
using HelpApp.Domain.Validation;
using FluentAssertions;
using Xunit;


namespace HelpApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName ="Create Product With Parameters Full")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Product Name", "Product Description", 9.99m, 99, "https://img/product.jpg", 2);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos
        [Fact(DisplayName ="Create Product With ID Negative")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 99.9m,
                99, "product image", 2);

            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image", "2");

            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters.");

        }

        [Fact(DisplayName = "Create Product With Null URL Image.")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product name","Product Description", 9.99m, 99, null, "2");

            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Create Product With URL Image Empty.")]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, "", "2");

            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();

        }



        [Theory(DisplayName = "Create Product With Invalid Price")]
        [InlineData(-25)]
    
        public void CreateProduct_InvalidPriceValue_DomainException(int value)
        {
            Action action = () => new Product("Product Name", "Product description", value, 99, "", 2);

            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>
            ().WithMessage("Invalid price negative value");
        }

        [Theory(DisplayName = "Create Product With Invalid Stock")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1,"Product Name", "Product description", 9.99m, 99, value, "product image", 2);

            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>
            ().WithMessage("Invalid stock negative value.");

        }

        [Theory(DisplayName = "Create Product With Long URL Image")]
        [InlineData("https://avatars.githubusercontent.com/u/658965487596532569854785236589654159658?v=4&size=65")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName(string url)
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, url, "product image");

            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>
            ().WithMessage("Invalid stock negative value.");

        }

        #endregion
    }
}
