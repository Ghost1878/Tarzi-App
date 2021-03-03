using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Services;

namespace Tarzi_Backend.Controllers.Apis
{
    [ApiController]
    [Route("/api/[controller]")]

    public class ApiCategoryController : Controller
    {
        private readonly IToastNotification _toast;
        private readonly CategoryService _categoryService; 

        public ApiCategoryController(CategoryService categoryService, IToastNotification toast)
        {
            _toast = toast;
            _categoryService = categoryService;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var uId = Convert.ToInt32(id);
                await _categoryService.Delete(uId);

                _toast.AddSuccessToastMessage("deleted success");
            }
            catch (System.Exception)
            {

                throw;
            }
            return Ok();
        }
    }
}
