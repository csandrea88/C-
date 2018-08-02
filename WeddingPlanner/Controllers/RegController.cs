using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
using System.Linq;
using WeddingPlanner.Models;
using WeddingPlanner.Factory;
using WeddingPlanner.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace WeddingPlanner.Controllers
{
    public class RegController : Controller
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
        private WeddingPlannerContext _context;

        public RegController(WeddingPlannerContext context)
        {
            // Dapper framework connections
            // _dbConnector = connect;
            // userFactory = new UserFactory();

            // Entity Framework connections
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("register")]
        [ImportModelState]
        public IActionResult Index()
        {
            ViewBag.errors = "";
            return View("Register");
        }

        [HttpPost]
        [Route("processreg")]
        
        public IActionResult Processreg(Regis newregis)
        {
            ViewBag.errors = "";
            TryValidateModel(newregis);
            if(ModelState.IsValid) {
                

                User NewUser = new User
                {
                    FName = newregis.FName,
                    LName = newregis.LName,
                    Email = newregis.Email,
                    Password = newregis.Password 
                };
                    _context.Add(NewUser);
                    _context.SaveChanges(); 
                        
                    HttpContext.Session.SetInt32("userid", (int)NewUser.UserId);
                    HttpContext.Session.SetString("FName",(string)NewUser.FName);

                    ViewBag.Fname = NewUser.FName;

                    return Redirect("Dashbd");

            } else {
                //ViewBag.errors = ModelState.Values;
                return View("Register");
            }
            
        }

    }
}
