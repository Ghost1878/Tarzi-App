using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Services;

namespace Tarzi_Backend.Controllers.Apis
{
    public class ApiOrderController : Controller
    {
        private readonly IToastNotification _toast;
        private readonly OrderService _orderService;

        public ApiOrderController(OrderService orderService, IToastNotification toast)
        {
            _toast = toast;
            _orderService = orderService;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var uId = Convert.ToInt32(id);
                await _orderService.Delete(uId);

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
