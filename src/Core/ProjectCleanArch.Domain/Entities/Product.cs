using ProjectCleanArch.Domain.Validation;

namespace ProjectCleanArch.Domain.Entities
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

        public Product(string name,
            string description,
            decimal price,
            int stock,
            string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name,
            string description,
            decimal price,
            int stock,
            string image)
        {
            DomainValidationException.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name,
            string description,
            decimal price,
            int stock,
            string image,
            int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name,
            string description,
            decimal price,
            int stock,
            string image)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name),
                "Invalid Name is required");

            DomainValidationException.When(name.Length < 3,
                "Invalid length to Name. Minimum 3 caracters");

            DomainValidationException.When(string.IsNullOrEmpty(description),
                "Invalid Description is required");

            DomainValidationException.When(description.Length < 5,
                "Invalid length to Description. Minimum 5 caracters");

            DomainValidationException.When(price < 0, "Invalid Price value");

            DomainValidationException.When(stock < 0, "Invalid Stock value");

            DomainValidationException.When(image?.Length > 250, "Invalid image name, too long, maximum 250 caracters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
