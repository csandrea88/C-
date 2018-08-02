using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
//using System.Linq;
//using AjaxNotes.Models;
//using AjaxNotes.Factory;
//using AjaxNotes.ActionFilters;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Newtonsoft.Json;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;
//using System.Security.Cryptography;
//using Microsoft.AspNetCore.Cryptography.KeyDerivation;
//using DbConnection;
using AjaxNotes;

namespace AjaxNotes.Controllers
{
    public class HomeController : Controller
    {

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Notes = DbConnector.Query("SELECT * FROM Notes");
            return View("Index");
        }

        // GET: /Home/
        [HttpPost]
        [Route("insert")]
        public IActionResult Insert(string title, string desc)
        {
           
            string query = "INSERT INTO Notes (title, description, created_On, updated_On) VALUES ('" + title + "', '" + desc + "' ,NOW(), NOW());";

            Console.WriteLine(query);
            
            DbConnector.Execute(query); 

            return RedirectToAction("Index");

        }
        
        // GET: /Home/
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            List<Dictionary<string, object>> Notes = DbConnector.Query("SELECT * FROM Notes Where id = " + id);
           
            if (Notes.Count == 1) {
                string query = "DELETE FROM Notes WHERE id = " + id;
                DbConnector.Execute(query);
            }
            return RedirectToAction("Index");
        }

        // GET: /Home/
        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(int id, string title, string desc)
        {
            List<Dictionary<string, object>> Notes = DbConnector.Query("SELECT * FROM Notes Where id = " + id);
           
            if (Notes.Count == 1) {
                string query = "UPDATE Notes SET title='" + title + "',description='" + desc + "',updated_On = NOW() where id = " + id;
                DbConnector.Execute(query);
            }
            return RedirectToAction("Index");
        }

    }
}
