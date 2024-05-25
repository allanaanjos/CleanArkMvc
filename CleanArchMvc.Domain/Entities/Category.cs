using System.Collections.Generic;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public Category(string name)
        {
            ValidationDomain(name);
        }

        public Category(int id, string name)
        {
           DomainExceptionValidation.When(id < 0, "Invalid Id value");
           Id = id;
           ValidationDomain(name);
        }

        public string Name { get; private set; } 
        public ICollection<Product> Products { get; private set; }


        public void Update(string name)
        {
           ValidationDomain(name);
        }

        public void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name Required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. too short, minimun 3 caracteres");

            Name = name;
        }
    
    }
}