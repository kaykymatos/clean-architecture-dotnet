using CleanArchProject.Domain.Validation;

namespace CleanArchProject.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id <= 0, "Invalid Id value.");
            Id = id;
            ValidationDomain(name, description, price, stock, image);
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = categoryId;

        }
        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
             "Invalid Name, Name is required!");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name, Name is too short, minimum 3 characters!");
            DomainExceptionValidation.When(name.Length > 100,
                "Invalid Name, Name is too large, maximum 100 characters!");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description),
             "Invalid Description, Description is required!");
            DomainExceptionValidation.When(description.Length < 3,
                "Invalid Description, Description is too short, minimum 3 characters!");
            DomainExceptionValidation.When(description.Length < 3,
                "Invalid Description, Description is too large, maximum 100 characters!");

            DomainExceptionValidation.When(price <= 0,
             "Invalid Price, Price need be greater than 0!");

            DomainExceptionValidation.When(stock <= 0,
             "Invalid Stock, Stock need be greater than 0!");

            DomainExceptionValidation.When(image?.Length > 250,
             "Invalid Image name, too long, maximum 250 characters!");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
