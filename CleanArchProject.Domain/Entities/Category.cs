using CleanArchProject.Domain.Validation;

namespace CleanArchProject.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }
        public Category(string name)
        {
            ValidationDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidationDomain(name);
        }
        public void UpdateName(string name)
        {
            ValidationDomain(name);
        }
        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid Name, Name is required!");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name, Name is too short, minimum 3 characters!");
            Name = name;
        }
    }
}
