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
            return View(nameof(HomeController.Index), new Equipment());
        }

        public IActionResult Create(string equipmentName)
        {
            var equipment = new Equipment();
            equipment.Name = equipmentName;
            return View("Index", equipment);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
