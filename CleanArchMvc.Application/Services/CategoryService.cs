using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interface;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interface;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryInterface
    {
      private ICategoryRepository _categoryRepo;
        private IMapper _mapper;
        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepository ?? 
                  throw new ArgumentNullException(nameof(categoryRepository));
        }
                
        public async Task Add(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepo.CreateAsync(category);
        }

        public async Task<Category> CategoryById(int? id)
        {
            var category = await  _categoryRepo.GetCategoryByIdAsync(id);
            return category;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _categoryRepo.GetCategoriesAsync();
        }

        public async Task Remove(int? id)
        {
            var category =  _categoryRepo.GetCategoryByIdAsync(id).Result;
            await _categoryRepo.DeleteAsync(category);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepo.UpdateAsync(category);
        }    }
}