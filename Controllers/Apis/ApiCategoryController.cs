using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Services;

namespace Tarzi_Backend.Controllers.Apis
{
    [ApiController]
    [Route("/api/[controller]")]

    public class ApiCategoryController : Controller
    {

        private readonly CategoryService _categoryService;

        public ApiCategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var uId = Convert.ToInt32(id);
                await _categoryService.Delete(uId);
            }
            catch (System.Exception)
            {

                throw;
            }
            // TempData["message"] = "تم حذف الصنف بنجاح";
            return Ok();
        }
    }
}
