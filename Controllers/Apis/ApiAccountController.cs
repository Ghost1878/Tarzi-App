using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Controllers.Apis
{
    [ApiController]
    [Route("/api/[controller]")]

    public class ApiAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApiAccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                await _userManager.DeleteAsync(user);
                //TempData["message"] = "تم حذف المستخدم بنجاح";
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
