using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
// using System.Linq;
 using loginRegis.Models;
//using loginRegis.Factory;
// using loginRegis.ActionFilters;
// using Microsoft.AspNetCore.Mvc.ModelBinding;
// using Newtonsoft.Json;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Identity;
// using System.Security.Cryptography;
// using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using DbConnection;

namespace loginRegis.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = "";
            return View("Index");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            ViewBag.errors = "";
            return View("Index");
        }


        [HttpPost]
        [Route("loginp")]
        public IActionResult Loginp(Login newlogin)
        {
            ViewBag.errors = "";
            TryValidateModel(newlogin);
            if(ModelState.IsValid) {
                
                List<Dictionary<string, object>> Users = DbConnector.Query("SELECT * FROM User Where Email = '" + newlogin.Email + "' AND Password = '" + newlogin.Password + "';");
                
                if (Users.Count == 1) {
                    ViewBag.errors = "Successful Login";
                    return View("Index");
                } else {
                    ViewBag.errors = "Invalid Login information";
                    return View("Index");
                }
                        
            } else {
                //ViewBag.errors = ModelState.Values;
                return View("Index");
            }
           
        }


        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            ViewBag.errors = "";
            return View("Index");
        }    
        
    }
}
