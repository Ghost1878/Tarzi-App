using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly OrderDetailsService _orderDetailsService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        [BindProperty]
        public CustomerOrderViewModel CustomerOrder { get; set; }
        public SelectList CustomersList { get; set; }
        public OrderController(SignInManager<ApplicationUser> signInManager, CategoryService categoryService, OrderDetailsService orderDetailsService, OrderService orderService, CustomerService customerService)
        {
            _orderService = orderService;
            _categoryService = categoryService;
            _customerService = customerService;
            _orderDetailsService = orderDetailsService;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var orders = await _orderService.GetAll();
            return View(orders);
        }
        [HttpGet]
        [Route("create-order")]
        public IActionResult Create()
        {
            var CustomerOrder = new CustomerOrderViewModel
            {
                Customers = _customerService.GetAll().Result.ToList(),
                Categories = _categoryService.GetAll().Result.ToList(),


            };
            return View(CustomerOrder);
        }
        [Route("create-order")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CustomerOrderViewModel model)
        {

            double tot = model.TotalAmount;
            double rec = model.ReceiptMonay;
            double rem = tot - rec;
            if (ModelState.IsValid)
            {
                Order order = new Order
                {
                    CategoryId = model.CategoryId,
                    ReceiptDate = model.ReceiptDate,
                    CustomerId = model.CustomerId,
                    OrderDetailsId = model.Id,
                    AddedByUser = _signInManager.UserManager.GetUserId(User),
                    ModifiedAt = DateTime.Now

                };
                await _orderService.Add(order);

                OrderDetails orderDetails = new OrderDetails
                {
                    CustomerName = model.FullName,
                    DarperyNeededLength = model.DarperyNeededLength,
                    Longness = model.Longness,
                    Neck = model.Neck,
                    Shoulder = model.Shoulder,
                    Side = model.Side,
                    SleeveLength = model.SleeveLength,
                    Phone = model.CustomerPhone,
                    Quantity = model.Quntity,
                    TotalAmount = model.TotalAmount,
                    ReceiptMonay = model.ReceiptMonay,
                    RemanentMonay = rem,
                    Sleevewasae = model.Sleevewasae,
                    DraperyFrom = model.DraperyFrom,
                    CreatedAt = model.CreatedAt,
                    ReceiptDate = model.ReceiptDate,
                    CustomerType = model.CustomerType,
                    OrderId = order.Id,

                    AddedByUser = _signInManager.UserManager.GetUserId(User),
                    ModifiedAt = DateTime.Now
                };

                await _orderDetailsService.Add(orderDetails);
            };
            TempData["message"] = "تم إضافة الطلب بنجاح!";
            return View(nameof(IndexAsync));
        }
    }
}