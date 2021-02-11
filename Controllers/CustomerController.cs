using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarzi_Backend.Data.Services;

namespace Tarzi_Backend.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _repo;

        public CustomerController(CustomerService repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {

            var customers = await _repo.GetAll();
            return View(customers);
        }
    }
}