using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
 
namespace Portfolio.Controllers
{
    public class PortController : Controller 
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");  
        }
    
        [HttpGet]
        [Route("/projects")]
        public IActionResult Projects()
        {
            return View("projects");  
        }
       
        [HttpGet]
        [Route("/contacts")]
        public IActionResult Contacts()
        {
             return View("contacts");
        }
    }
}