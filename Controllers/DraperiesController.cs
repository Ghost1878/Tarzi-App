using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Services;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Controllers
{
    //[Authorize]
    public class DraperiesController : Controller
    {
        private readonly DraperiesService _draperiesService;
        [BindProperty]
        public DraperiesType DraperiesType { get; set; }

        public DraperiesController(DraperiesService draperiesService)
        {
            _draperiesService = draperiesService;
        }
        // GET: DraperiesController
        public async Task<ActionResult> Index()
        {
            var DraperiesType = await _draperiesService.GetAll();
            return View(DraperiesType);
        }
        // GET: DraperiesController/Create
        [HttpGet]
        [Route("Draperies/Drapery-form")]
        public async Task<ActionResult> Create(int? id)
        {
            DraperiesType = new DraperiesType();
            if (id == null)
            {
                return View(DraperiesType);
            }
            //int cusId = Convert.ToInt32(id);
            DraperiesType = await _draperiesService.GetById((int)id);
            if (DraperiesType == null)
            {
                return NotFound();
            }
            return View(DraperiesType);
        }

        // POST: DraperiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Draperies/Drapery-form")]
        public async Task<ActionResult> Create()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (DraperiesType.Id == 0)
                    {
                        await _draperiesService.Add(DraperiesType);
                    }
                    else
                    {
                        await _draperiesService.Update(DraperiesType);

                    }
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: DraperiesController/Delete/5
        [Route("Draperies/delete-drapery")]
        public async Task<ActionResult> Delete(int id)
        {
            DraperiesType = await _draperiesService.GetById(id);
            return View(DraperiesType);
        }

        // POST: DraperiesController/Delete/5
        [HttpPost]
        [Route("Draperies/delete-drapery")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete()
        {
            try
            {
                var id = DraperiesType.Id;
                await _draperiesService.Delete(id);
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
