using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
 
namespace Dojosurvey.Controllers
{
    public class SurveyController : Controller 
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");  
        }
    
        [HttpPost]
        [Route("method")]
        public IActionResult Method(string name, string dojoloc, string favlang, string comment)
        {
            ViewBag.name = name;
            ViewBag.dojoloc = dojoloc;
            ViewBag.favlang = favlang;
            ViewBag.comment = comment;
            
            return View("process");  
        }    
       
       
    }
}