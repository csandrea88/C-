using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
 
namespace TimeDisplay.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");  
        }
    }
}