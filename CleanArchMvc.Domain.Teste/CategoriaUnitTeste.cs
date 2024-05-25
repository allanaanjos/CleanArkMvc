using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Teste
{
    public class CategoriaUnitTeste
    {
        [Fact]
        public void CreateCategory_WithValidParemeters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "CategoriaName");

            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValueParemeter_DomainExceptionValidation()
        {
            Action action = () => new Category(-1, "CategoriaName");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_TooShortName_DomainExceptionValidation()
        {
            Action action = () => new Category(1, "Ca");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid name. too short, minimun 3 caracteres");
        }

        
        [Fact]
        public void CreateCategory_MIssingNameValue_DomainExceptionValidationNameRequired()
        {
            Action action = () => new Category(1, "");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid name. Name Required");
        }

         [Fact]
        public void CreateCategory_MIssingNullNameValue_ValidObject()
        {
            Action action = () => new Category(1, "");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        
    }
}
