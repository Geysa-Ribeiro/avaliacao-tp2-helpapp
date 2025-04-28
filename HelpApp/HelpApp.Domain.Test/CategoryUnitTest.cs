using HelpApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using HelpApp.Domain.Validation;
using System;
using System.ComponentModel;

namespace HelpApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Should create a valid category with id and name")]
        public void CreateCategory_WithValidParameters_ShoulCreatedObject()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos
        [Fact(DisplayName = "Create Category With Name Empty")]

        public void CreateCategory_WithNameEmpty_ResultObjectException()
        {
            Action action = () => new Category(1, "");

            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, name is required.");
        }

        #endregion
    }

}
