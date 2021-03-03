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
    // [Authorize]
    public class ApiDraperiesController : Controller
    { 
        private readonly IToastNotification _toast; 
        private readonly DraperiesService _draperiesService;

        public ApiDraperiesController(DraperiesService draperiesService, IToastNotification toast)
        {
            _toast = toast; 
            _draperiesService = draperiesService;
        } 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var uId = Convert.ToInt32(id); 
                await _draperiesService.Delete(uId);

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
