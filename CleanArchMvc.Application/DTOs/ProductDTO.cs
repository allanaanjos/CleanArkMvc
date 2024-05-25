using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(100)]
        [MinLength(5)]
         public string Description { get; set; }
        
        [Required(ErrorMessage = "Price is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Stock is required")]
        [Range(1, 9999)]
        public int Stock { get; set; } 
        
        [MaxLength(250)]
        public string Image { get; set; }

        public Category Category { get; set; } 

        public int CategoryId { get; set; }
    }
}