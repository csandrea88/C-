using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using futureAPI;
using futureAPI.Models;

namespace futureAPI.Controllers
{
   
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //For future Database calls or possible future entity framework connections.
            //I would setup a database connection to a database and execute a query, while using a try and catch, to  
            //catch error messages the program ends abnormally.

            //Each Title will have its ID appended to the end of each Title

            //ViewBag.Titles = List of Titles: of class = Title.
            
            return View("Index");
        }

        [HttpGet]
        [Route("Result")]
        public IActionResult Result()
        {
            return View("Result");
        }
        
        [HttpGet]
        [Route("get")]
        public IActionResult GetbyId(int id, string title, string desc)
       {
            //Get Title in textbox, query database by title to retreive an ID. 
            //Possible then adding it to viewbag or use razor for add future functionality 
            
            return RedirectToAction("Result");
       }

        // POST api/values
        [HttpPost]
        [Route("insert")]  
        public IActionResult Insert(string title, string desc)
        {      
            //Create a new class = Title, assign form data to new class properties, and perform database insert to database
            return RedirectToAction("Result");
        }

        //PUT update
        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(int id, string title)
       {
            //Perform both a Get and then an update query by id to change a title in the database.
            return RedirectToAction("Result");
       }

        //DELETE api/values/5
        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            // Perform a delete query to remove title from database
            return RedirectToAction("Result");
        }
    }
}
