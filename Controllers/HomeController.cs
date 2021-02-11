using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Data.Services;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepo<Customer> _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IGenericRepo<Customer> repo, ILogger<HomeController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _repo.GetAll();
            if (customers == null)
                return NoContent();
            return View(customers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
