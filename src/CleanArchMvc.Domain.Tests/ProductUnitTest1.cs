using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CrerateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1,"Product Name","Product Description",9.99m,99,"product image");

            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreatePorduct_NegativeIdValue_domainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_EmptyProductNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
            
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, Name is Required");
        }

        [Fact]
        public void CreateProduct_NullProductNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "product image");
            
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, Name is Required");
        }

        [Fact]
        public void CreateProduct_EmptyDescriptionValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "product image");
            
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, Description is Required");
        }

        [Fact]
        public void CreateProduct_NullDescriptionValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Procut Name", null, 9.99m, 99, "product image");
            
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, Description is Required");
        }

        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Procut Name", "De", 9.99m, 99, "product image");
            
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99
                , "loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo long");
            
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "ProductionDescription", 9.99m, value, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidPriceValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "ProductionDescription", value, 99, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);

            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}