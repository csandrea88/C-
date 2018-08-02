using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
using System.Linq;
using Belt1CSharp.Models;
using Belt1CSharp.Factory;
using Belt1CSharp.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace Belt1CSharp.Controllers
{
    public class LoginController : Controller
    {
        // ########## ROUTES ##########
        //  /
        //  /(add_routes_guide)
        //  /
        // ########## ROUTES ##########

        // Dapper connections
        // private readonly UserFactory userFactory;
        // private readonly DbConnector _dbConnector;

        // Entity PostGres Code First connection
        private Belt1CSharpContext _context;

        public LoginController(Belt1CSharpContext context)
        {
            // Dapper framework connections
            // _dbConnector = connect;
            // userFactory = new UserFactory();

            // Entity Framework connections
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        [ImportModelState]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            ViewBag.errors = "";
            return View("Index");
        }


        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            ViewBag.errors = "";
            
            HttpContext.Session.Remove("userid");
            HttpContext.Session.Remove("FName");

            return View("Index");
        }
        
                // [HttpPost]
        [Route("loginp")]
        public IActionResult Loginp(Login newlogin)
        {
            ViewBag.errors = "";
            TryValidateModel(newlogin);
            if(ModelState.IsValid) {
               
                
                User userloginemail = _context.Users.SingleOrDefault (s => s.Email == newlogin.Email);
                if (userloginemail != null) {
                    
                    
                    if (userloginemail.Password == newlogin.Password) {
                        
                        HttpContext.Session.SetInt32("userid", (int)userloginemail.UserId);
                        HttpContext.Session.SetString("FName",(string)userloginemail.FName);
                        
                        ViewBag.Fname = userloginemail.FName;

                        
                        return RedirectToAction("Home","Home");

                    } else {

                        ViewBag.errors = "Incorrect Password";
                        return View("Index");
                    }

                } else {
                    ViewBag.errors = "Invalid Email";
                    return View("Index");
                }
                       
            } else {
                //ViewBag.errors = ModelState.Values;
                return View("Index");
            }
           
        }


    }
}
