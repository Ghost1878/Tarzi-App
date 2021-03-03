using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Services;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Controllers
{
   // [Authorize]
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService;
        [BindProperty]
        public Category Category { get; set; }

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: CategoriesController
        public async Task<ActionResult> Index()
        {
            var Categories = await _categoryService.GetAll();
            return View(Categories);
        }

        [Route("categories/category-form")]
        public async Task<ActionResult> Create(int? id)
        {
            Category = new Category();
            if (id == null)
            {
                return View(Category);
            }
            Category = await _categoryService.GetById((int)id);
            return View(Category);
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("categories/category-form")]
        public async Task<ActionResult> Create()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Category.Id == 0)
                    {
                        await _categoryService.Add(Category);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        await _categoryService.Update(Category);
                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletee(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
