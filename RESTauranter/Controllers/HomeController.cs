using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
using System.Linq;
using RESTauranter.Models;
using RESTauranter.Factory;
using RESTauranter.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private RESTauranterContext _context;

        public HomeController(RESTauranterContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("addRev")]
        public IActionResult AddRev(REST newREST) {
            
            TryValidateModel(newREST);

            if(ModelState.IsValid) {

                _context.Add(newREST);
                _context.SaveChanges(); 

                List<REST> AllRESTs = _context.RESTauranter.OrderByDescending(x => x.VisitDate).ToList();
                ViewBag.RESTs = AllRESTs;
                return View("ShowRev");

            } else {
                return View ("Index");
            }
        }


    }
}
