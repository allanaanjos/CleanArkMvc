using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();

        //Task<ProductDTO> GetProductCategoriesAsync(int? id);

        Task<ProductDTO> ProductById(int? id);

        Task Add(ProductDTO productDTO);

        Task Update(ProductDTO productDTO);

        Task Remove(int? id);
    }
}