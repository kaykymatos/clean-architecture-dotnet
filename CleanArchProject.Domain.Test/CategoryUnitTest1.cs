using CleanArchProject.Domain.Entities;
using FluentAssertions;

namespace CleanArchProject.Domain.Test
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<CleanArchProject.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateCategory_NavigateIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<CleanArchProject.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
        [Fact]
        public void CreateCategory_SortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<CleanArchProject.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is too short, minimum 3 characters!");
        }
        [Fact]
        public void CreateCategory_Null_DomainException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<CleanArchProject.Domain.Validation.DomainExceptionValidation>();
        }
    }
}