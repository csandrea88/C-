using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
//using System.Linq;
//using qtgdojo.Models;
//using qtgdojo.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
//using Microsoft.EntityFrameworkCore;
using DbConnection;


namespace qtgdojo.Controllers
{
    public class QtgController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpPost]
        [Route("quote")]
        public IActionResult Quotep(string name, string quote)
        {
          
            string query = "INSERT INTO Quotes(Name,Quote,Updated_at,Created_at) VALUES ('" + name + "','" + quote + "' ,NOW(), NOW() )";
            //Console.WriteLine(query);

            DbConnector.Execute(query);

            return RedirectToAction("Quoteg");
        }

        [HttpGet]
        [Route("quoteget")]
        public IActionResult Quoteg()
        {
            List<Dictionary<string, object>> Quotes = DbConnector.Query("SELECT * FROM Quotes");
            
            ViewBag.Quotes = Quotes;
            
            return View("quote");
        }

    }
}
