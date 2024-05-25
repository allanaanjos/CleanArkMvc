using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Teste
{
    public class ProductUnitTeste
    {
        [Fact]
        public void CreateProduct_WithValidObject_ResultValidStated()
        {
            Action action = () => new Product(1, "produto1", "product description", 9.99m, 20, "image Product");

            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

         [Fact]
        public void CreateProduct_NegativeIdValue_ResultDomainExceptin()
        {
            Action action = () => new Product(-1, "produto1", "product description", 9.99m, 20, "image Product");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid id value");
        }

         [Fact]
        public void CreateProduct_NameNullValue_ResultDomainException()
        {
            Action action = () => new Product(1, "", "product description", 9.99m, 20, "image Product");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name. Name required");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_ResultDomainException()
        {
            Action action = () => new Product(1, "pr", "product description", 9.99m, 20, "image Product");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name. too short, minimun 3 caracteres");
        }

        [Fact]
        public void CreateProduct_ImageNullValue_ResultValidObject()
        {
            Action action = () => new Product(1, "produto", "product description", 9.99m, 20, null);

            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

         [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "produto", "product description", 9.99m, 20, null);

            action.Should().NotThrow<NullReferenceException>();
        }


        [Fact]
        public void CreateProduct_TooLongImageValue_ResultDomainException()
        {
            Action action = () => new Product(1, "produto", "product description", 9.99m, 20, 
            "toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooonggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                     .WithMessage("Invalid image name, too long, maximun 250 caracteres");
        }


        
        [Fact]
        public void CreateProduct_PriceInvalidValue_ResultDomainException()
        {
            Action action = () => new Product(1, "produto", "product description", -2.0m, 20, null);

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid price value");
        }  

        [Fact]
        public void CreateProduct_StockInvalidValue_ResultDomainException()
        {
            Action action = () => new Product(1, "produto", "product description", 9.99m, -1, null);

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid stock value");
        }     

        [Fact]
        public void CreateProduct_DescriptionNullValue_ResultDomainException()
        {
            Action action = () => new Product(1, "produto", null, 9.99m, 1, "image peoduct");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid description. Description required");
        }            
    }
}