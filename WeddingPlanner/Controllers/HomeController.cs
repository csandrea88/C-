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
    public class HomeController : Controller
    {
        private WeddingPlannerContext _context;

        public HomeController(WeddingPlannerContext context)
        {
            // Entity Framework connections
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("dashbd")]
        [ImportModelState]
        public IActionResult Dashbd()
        {
            int? userid = HttpContext.Session.GetInt32("userid");
            User CurrUser = _context.Users.SingleOrDefault (s => s.UserId == userid);
            
            ViewBag.userid = (int)userid;

            List <WedPlanr> Wedplanrs = _context.Wedplanrs.Include(user => user.Users).ToList();
            ViewBag.Wedplanrs = Wedplanrs;

            ViewBag.RSVPs = _context.RSVPs.Where(s => s.UserId == userid).ToList();
                        
            return View("Dashbd");
        }

                // GET: /Home/
        // [HttpGet]
        // [Route("")]
        // [ImportModelState]
        // public IActionResult Dashbd()
        // {
        //     return View("Dashbd");
        // }


    }
}
