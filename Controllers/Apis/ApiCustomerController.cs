using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Tarzi_Backend.Data.Services;

namespace Tarzi_Backend.Controllers.Apis
{
    [ApiController]
    [Route("/api/[controller]")]
   // [Authorize]
    public class ApiCustomerController : ControllerBase
    {
        private readonly IToastNotification _toast;
        private readonly CustomerService _customerService; 

        public ApiCustomerController(CustomerService customerService , IToastNotification toast)
        {
            _toast = toast;
            _customerService = customerService; 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var uId = Convert.ToInt32(id);
                await _customerService.Delete(uId);

                _toast.AddSuccessToastMessage("deleted success");
            }
            catch (System.Exception)
            {

                throw;
            }
            return Ok();
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCustomer(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var customer = await _customerService.GetById(id);
        //        if (customer == null)
        //            return NotFound("no customer found");
        //        return Ok(customer);
        //    }
        //    return NotFound();




    }
}