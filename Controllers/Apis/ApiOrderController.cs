using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Services;

namespace Tarzi_Backend.Controllers.Apis
{
    public class ApiOrderController : Controller
    {

        private readonly OrderService _orderService;

        public ApiOrderController(OrderService orderService)
        {

            _orderService = orderService;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var uId = Convert.ToInt32(id);
                await _orderService.Delete(uId);

            }
            catch (System.Exception)
            {
                throw;
            }
            return Ok();
        }
    }
}
