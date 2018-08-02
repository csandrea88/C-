using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
using System.Linq;
using LostWoods.Models;
using LostWoods.Factory;
using LostWoods.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace LostWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailsFactory trailFactory;
        public HomeController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            trailFactory = new TrailsFactory();
        }
        

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.trail = trailFactory.FindAll();
            return View("Index");
        }
        
        [HttpGet]
        [Route("show/{id}")]
        public IActionResult Show(int id)
        {
            ViewBag.trail = trailFactory.FindByID(id);
            return View("ShowTrails");
        }

        [HttpGet]
        [Route("insert")]
        public IActionResult Insert()
        {
            return View ("Insert");
        }

        [HttpPost]
        [Route("addtrail")]
        public IActionResult AddTrail(Trail newtrail)
        {
            TryValidateModel(newtrail);
            if(ModelState.IsValid) {
                trailFactory.Add(newtrail);
                return RedirectToAction ("Index");
            } else {
                return View("Insert");
            }
        }

        [HttpPost]
        [Route("gohome")]
        
        public IActionResult GoHome()
        {
            return RedirectToAction ("Index");
        }        
    }
}
