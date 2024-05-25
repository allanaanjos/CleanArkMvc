using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}