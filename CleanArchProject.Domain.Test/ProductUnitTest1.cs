using CleanArchProject.Domain.Entities;
using FluentAssertions;

namespace CleanArchProject.Domain.Test
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "My Description", 100.00m, 10, "Desc Image");
            action.Should().NotThrow<CleanArchProject.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_NavigateIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "My Description", 100.00m, 10, "Desc Image");
            action.Should().Throw<CleanArchProject.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
        [Fact]
        public void CreateProduct_SortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "My Description", 100.00m, 10, "Desc Image");
            action.Should().Throw<CleanArchProject.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is too short, minimum 3 characters!");
        }
        [Fact]
        public void CreateProduct_TooLargeName_DomainException()
        {
            Action action = () => new Product(1, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "My Description", 100.00m, 10, "Desc Image");
            action.Should().Throw<CleanArchProject.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is too large, maximum 100 characters!");
        }
        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStock_DomainExceptionNegativeValue(int value)
        {
            Action action = () => new Product(1, "Teste produto", "My Description", 100.00m, value, "Desc Image");
            action.Should().Throw<CleanArchProject.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Stock, Stock need be greater than 0!");
        }
        [Fact]
        public void CreateProduct_PriceInvalid_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Teste", "My Description", -100.00m, 10, "Desc Image");
            action.Should().Throw<CleanArchProject.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Price, Price need be greater than 0!");
        }
        [Fact]
        public void CreateProduct_NullImageName_NoDomainExceptionInvalid()
        {
            Action action = () => new Product(1, "Teste", "My Description", -100.00m, 10, null);
            action.Should().Throw<CleanArchProject.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Price, Price need be greater than 0!");
        }
        [Fact]
        public void CreateProduct_NullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Teste", "My Description", -100.00m, 10, null);
            action.Should().NotThrow<NullReferenceException>();
        }
    }
}
