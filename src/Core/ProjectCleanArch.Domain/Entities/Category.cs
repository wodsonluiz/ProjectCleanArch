using ProjectCleanArch.Domain.Validation;

namespace ProjectCleanArch.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainValidationException.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name),
                "Invalid Name is required");

            DomainValidationException.When(name.Length < 3,
                "Invalid length to Name. Minimum 3 caracters");

            Name = name;
        }
    }
}
