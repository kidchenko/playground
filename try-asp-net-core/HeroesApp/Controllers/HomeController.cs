using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeroesApp.Models;

namespace HeroesApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(nameof(HomeController.Index), Equipment.GetAll());
        }

        public IActionResult Create(string equipmentName)
        {
            Equipment.Create(equipmentName);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
