using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
using System.Linq;
using BankAccts.Models;
using BankAccts.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace BankAccts.Controllers
{
    public class BAccController : Controller
    {
        
        // Entity PostGres Code First connection
        private BankAcctsContext _context;

        public BAccController(BankAcctsContext context)
        {
    
            // Entity Framework connections
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("account")]
        [ImportModelState]
        public IActionResult Account()
        {
            ViewBag.CurrUser = "";
            //get users id's balance

            int? UserId = HttpContext.Session.GetInt32("userid");
            
            string FName = HttpContext.Session.GetString("FName");
  
            User CurrUser = _context.Users.Include(user => user.Trans).SingleOrDefault (s => s.UserId == UserId);
        
            ViewBag.CurrUser = CurrUser;

            return View("Account");
        }

        [HttpPost]
        [Route("subTrans")]
        [ImportModelState]
        public IActionResult SubTrans (int TransAmt)
        {
            int? UserId = HttpContext.Session.GetInt32("userid");

            User CurrUser = _context.Users.Include(user => user.Trans).SingleOrDefault (s => s.UserId == UserId);
            
            int newBal = CurrUser.Balance + (int)TransAmt;
            
            BAcc NewTrans = new BAcc
                {
                    Amount = TransAmt,   //Create New Transaction
                    UserId = (int)UserId,
                    Date = DateTime.Now,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now
                };
                    CurrUser.Balance += (int)TransAmt; //Update Balance field to User table

                    _context.Add(NewTrans);
                    _context.SaveChanges(); 

            // User NewUsers = new User
            //     {
            //         UserId = CurrUser.UserId,
            //         Balance = newBal
            //     };  
            //         _context.SaveChanges(); 
            
            return RedirectToAction("Account", "BAcc");
            
        }
    }
}
