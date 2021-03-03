using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tarzi_Backend.Data.Services;
using Tarzi_Backend.Models;
using Tarzi_Backend.ViewModels;

namespace Tarzi_Backend.Controllers
{
    //[Authorize]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        private readonly CategoryService _categoryService;
        private readonly CustomerService _customerService;

        [BindProperty]
        public CustomerOrderViewModel CustomerOrder { get; set; }
        public SelectList CustomersList { get; set; }
        public OrderController(CategoryService categoryService, OrderService orderService, CustomerService customerService)
        {
            _orderService = orderService;
            _categoryService = categoryService;
            _customerService = customerService;
        }
        public  IActionResult Index()
        {
           // var orders = await _orderService.GetAll();
            return View();
        }
        [HttpGet]
        [Route("create-order")]
        public async Task<IActionResult>  Create()
        {


            //lists.(new SelectListItem { Text = "عميل مسجل", Value = "1", Selected = true });
            //lists.Add(new SelectListItem { Text = "زبون", Value = "0", Selected = false });
            var CustomerOrder = new CustomerOrderViewModel
            {
                Customers = _customerService.GetAll().Result.ToList(),
                Categories = _categoryService.GetAll().Result.ToList(),


            }; 
            return View(CustomerOrder);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerOrderViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}