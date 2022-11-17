using Kunskapsprov.Connection;
using Kunskapsprov.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Kunskapsprov.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; 

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Person.ToListAsync());
        }


        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person model)
        {
            _context.Person.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View("Create");
        }



        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var data = await _context.Person.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(data);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Person Model)
        {
            var data = await _context.Person.Where(x => x.Id == Model.Id).FirstOrDefaultAsync();
            if (data != null)
            {
                data.Address = Model.Address;
                data.FirstName = Model.FirstName;
                data.LastName = Model.LastName;
                await _context.SaveChanges();
            }

            return RedirectToAction("index");
        }


        public async Task<ActionResult> Detail(int id)
        {
            var data = await _context.Person.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(data);
        }


        public ActionResult Delete(int id)
        {
            var data = _context.Person.Where(x => x.Id == id).FirstOrDefault();
            _context.Person.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }




    }
}
