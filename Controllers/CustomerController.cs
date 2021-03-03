using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Data.Services;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Controllers
{

    [Authorize]
    public class CustomerController : Controller
    {
        private readonly CustomerService _repo;
        private readonly IToastNotification _toast;

        [BindProperty]
        public Customer Customer { get; set; }

        public CustomerController(CustomerService repo, IToastNotification toast)
        {
            _repo = repo;
            _toast = toast;
        }
        public async Task<IActionResult> Index()
        {
            _toast.AddSuccessToastMessage("is succuess");
            var customers = await _repo.GetAll();
            return View(customers);
        }

        [Route("customer/order-form")]
        [HttpGet]
        public async Task<IActionResult> AddOrder(int? id)
        {
            //Customer = new Customer();
            //if (id == null)
            //{
            //    return View(Customer);
            //}
            ////int cusId = Convert.ToInt32(id);
            //Customer = await _repo.GetById((int)id);
            //if (Customer == null)
            //{
            //    return NotFound();
            //}
            return View();
        }
        [Route("customer/customer-form")]
        [HttpGet]
        public async Task<IActionResult> CustomerForm(int? id)
        {
            Customer = new Customer();
            if (id == null)
            {
                return View(Customer);
            }
            //int cusId = Convert.ToInt32(id);
            Customer = await _repo.GetById((int)id);
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }
        [HttpPost]
        [Route("customer/customer-form")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerForm()
        {
            if (ModelState.IsValid)
            {
                //if (Customer != null)
                //{
                //    await _repo.Add(Customer);
                //    return RedirectToAction("Index");
                //}

                if (Customer.Id == 0)
                {
                    await _repo.Add(Customer);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    await _repo.Update(Customer);
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Customer = await _repo.GetById(id);
            return View(Customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update()
        {
            if (ModelState.IsValid)
            {
                await _repo.Update(Customer);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Customer = await _repo.GetById(id);
            return View(Customer);
            //  return PartialView("_DeleteCustomer", Customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove()
        {
            var id = Customer.Id;
            await _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}