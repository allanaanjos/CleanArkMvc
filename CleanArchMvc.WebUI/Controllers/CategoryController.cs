using System;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryInterface _categoryService;

        public CategoryController(ICategoryInterface CategoryService)
        {
            _categoryService = CategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var category = await _categoryService.Categories();
            return View(category);
        }


       [HttpPost]
       public async Task<IActionResult> Create(CategoryDTO categoryDTO)
       {
          if(ModelState.IsValid){
                await _categoryService.Add(categoryDTO);
                return RedirectToAction(nameof(Index));
          }

          return View();
       }

       [HttpPut]
       public async Task<IActionResult> Edit(int? id)
       {
          if(id == null) return NotFound();

          var categoryId = await _categoryService.CategoryById(id); 

          if(categoryId == null)return NotFound();

          return View(categoryId);
       }

       [HttpPost()]
       public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
       {
           if(ModelState.IsValid)
           {

              try
              {
                await _categoryService.Update(categoryDTO);
              }
              catch (Exception)
              {
                
                throw;
              }

              return RedirectToAction(nameof(Index));
           }

           return View(categoryDTO);
       }


    }
}