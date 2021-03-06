using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Services;
using Tarzi_Backend.Models;
using X.PagedList;


namespace Tarzi_Backend.Controllers
{

    [Authorize]
    public class CustomerController : Controller
    {
        private readonly CustomerService _repo;

        [BindProperty]
        public Customer Customer { get; set; }

        public CustomerController(CustomerService repo)
        {
            _repo = repo;

        }
        public async Task<IActionResult> Index(int? page)
        {
            var customers = await _repo.GetAll();

            // var pageNumber = page ?? 1;
            // int pageSize = 25;
            var onPageOfCustomer = customers.ToPagedList(page ?? 1, 25);
            return View(onPageOfCustomer);
        }

        //[Route("customer/order-form")]
        // [HttpGet]
        //public async Task<IActionResult> AddOrder(int? id)
        //{
        //    //Customer = new Customer();
        //    //if (id == null)
        //    //{
        //    //    return View(Customer);
        //    //}
        //    ////int cusId = Convert.ToInt32(id);
        //    //Customer = await _repo.GetById((int)id);
        //    //if (Customer == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    return View();
        //}
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

                if (Customer.CustomerId == 0)
                {
                    await _repo.Add(Customer);
                    TempData["message"] = "تم إضافة العميل بنجاح";
                }
                else
                {
                    await _repo.Update(Customer);
                    TempData["message"] = "تم تعديل بيانات العميل بنجاح!";

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
            var id = Customer.CustomerId;
            await _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}