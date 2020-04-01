﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CretaceousClient.Models;

namespace CretaceousClient.Controllers
{
    public class AnimalsController : Controller
    {
        public IActionResult Index()
        {
            var allAnimals = Animal.GetAnimals();
            return View(allAnimals);
        }

        public IActionResult Details(int id)
        {
        var animal = Animal.GetDetails(id);
        return View(animal);
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