using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        
         public Product( int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            ValidationDomain(name,description,price,stock,image);
        }

        public Product( string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name,description,price,stock,image);
        }


        public void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                   "Invalid name. Name required");
            DomainExceptionValidation.When(name.Length < 3, 
                   "Invalid name. too short, minimun 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), 
                   "Invalid description. Description required");
            DomainExceptionValidation.When(description.Length < 5, 
                   "Invalid description. too short, minimun 5 caracteres");
            DomainExceptionValidation.When(price < 0, 
                   "Invalid price value");
            DomainExceptionValidation.When(stock < 0, 
                   "Invalid stock value");
            DomainExceptionValidation.When(image?.Length > 250, 
                   "Invalid image name, too long, maximun 250 caracteres"); 


            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

         public void  Update( string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidationDomain(name,description,price,stock,image);
            CategoryId = categoryId;
        }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}