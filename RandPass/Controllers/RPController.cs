using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
 
namespace RandPass.Controllers
{
    public class RPController : Controller 
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
    
            int? count = HttpContext.Session.GetInt32("num");
            if (count == null) {
                count = 0;
            }
            count ++;
            HttpContext.Session.SetInt32("num", (int)count);

            ViewBag.count = count;

            return View("index"); 
        }
 
    
        [HttpGet]
        [Route("generate")]
        public IActionResult generate()
        {
            return RedirectToAction("Index"); 
        }  
    }
}