using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Interface
{
    public interface ICategoryInterface
    {
        Task<IEnumerable<Category>> Categories();

        Task<Category> CategoryById(int? id);

        Task Add(CategoryDTO categoryDTO);

        Task Update(CategoryDTO categoryDTO);

        Task Remove(int? id);
    }
}