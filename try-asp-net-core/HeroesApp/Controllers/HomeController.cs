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
            var equipment = new Equipment();
            equipment.Name = "Shield";
            return View(nameof(HomeController.Index), equipment);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
