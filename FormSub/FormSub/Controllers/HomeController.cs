using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
//using System.Linq;

//using FormSub.Factory;
//using FormSub.ActionFilters;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Newtonsoft.Json;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using System.Security.Cryptography;
//using Microsoft.AspNetCore.Cryptography.KeyDerivation;
//using DbConnection;
using FormSub.Models;

namespace FormSub.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }


        [HttpPost]
        [Route("process")]
        public IActionResult Process(string fname, string lname, int age, string email, string password)
        {
           
            User NewUser = new User
            {
                FName = fname,
                LName = lname,
                Age = age,
                Email = email,
                Password = password
            };
            TryValidateModel(NewUser);
            
            ViewBag.errors = ModelState.Values;

            return View("Results");
        }
    }
}
