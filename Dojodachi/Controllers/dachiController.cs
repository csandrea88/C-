using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
 
namespace Dojodachi.Controllers
{
    public class dachiController : Controller 
    {
        private void initsess() {

            int? sfull = HttpContext.Session.GetInt32("full");
            if (sfull == null) {
                sfull = 20; 
                HttpContext.Session.SetInt32("full", (int)sfull);
            }
            
            int? shappy = HttpContext.Session.GetInt32("happy");
            if (shappy == null) { 
                shappy = 20; 
                HttpContext.Session.SetInt32("happy", (int)shappy);
            }
            
            int? senergy = HttpContext.Session.GetInt32("energy");
            if (senergy == null) { 
                senergy = 50; 
                HttpContext.Session.SetInt32("energy", (int)senergy);
            }
            
            int? smeals = HttpContext.Session.GetInt32("meals");
            if (smeals == null) { 
                smeals = 3; 
                HttpContext.Session.SetInt32("meals", (int)smeals);
                }
        
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            initsess();

            ViewBag.full = HttpContext.Session.GetInt32("full");
            ViewBag.happy = HttpContext.Session.GetInt32("happy");
            ViewBag.energy = HttpContext.Session.GetInt32("energy");
            ViewBag.meals = HttpContext.Session.GetInt32("meals");
            ViewBag.msg = TempData["Msg"];
            
            if (ViewBag.full <= 0 & ViewBag.happy <= 0){
                ViewBag.status = "Lost";
                ViewBag.msg = "You Lost";
            } else if (ViewBag.full >= 100 & ViewBag.happy >=100) {
                ViewBag.status = "Won";
                ViewBag.msg = "You Won";
            }


            return View("index"); 
        }

        [HttpGet]
        [Route("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("feed")]
        public IActionResult Feed()
        {
            int? smeals = HttpContext.Session.GetInt32("meals");
            int? sfull = HttpContext.Session.GetInt32("full");
            
            if (smeals >= 1) {

                smeals --;
                int k = 0;
                Random rand = new Random();
                int l = rand.Next(1,4);
                if (l==1) {                  
                    k = rand.Next(5,10);
                    sfull += k;                  
                }

                HttpContext.Session.SetInt32("meals", (int)smeals);
                HttpContext.Session.SetInt32("full", (int)sfull);

                if (k == 0) {
                        TempData["Msg"] = "Turtledachi played, meals: -1 and fullness: 0, Turtle dachi didn't like it";

                    } else {
                        TempData["Msg"] = "Turtledachi played, meals: -1 and happiness: +" + k;

                     }
           
            } else {

                TempData["Msg"] = "Poor hungry Turtledachi, not enoungh meal points to eat";
                
            }
            
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        [Route("play")]
        public IActionResult Play()
        {
            int? senergy = HttpContext.Session.GetInt32("energy");
            int? shappy = HttpContext.Session.GetInt32("happy");

            if (senergy >= 5) {
                    int k = 0;
                    senergy -= 5;
                    Random rand = new Random();
                    int l = rand.Next(1,4);
                    if (l==1) {                    
                        k = rand.Next(5,10);
                        shappy += k;
                    }
                    HttpContext.Session.SetInt32("energy", (int)senergy);
                    HttpContext.Session.SetInt32("happy", (int)shappy);

                    if (k == 0) {
                        TempData["Msg"] = "Turledachi played, energy: -5 and happiness: +" + k + " happiness, Turtle dachi didn't like it";

                    } else {
                        TempData["Msg"] = "Turtledachi played, energy: -5 and happiness: +" + k;

                    }

            } else {

                    TempData["Msg"] = "Poor Turtledachi didn't play, not enoungh energy points";
                    
            }

            return RedirectToAction("Index"); 
        }  

        [HttpGet]
        [Route("work")]
        public IActionResult Work()
        {
            int? smeals = HttpContext.Session.GetInt32("meals");
            int? senergy = HttpContext.Session.GetInt32("energy");
            
            if (senergy >= 5) {

                senergy -= 5;
                Random rand = new Random();
                int k = rand.Next(1,3);
                smeals += k;

                HttpContext.Session.SetInt32("meals", (int)smeals);
                HttpContext.Session.SetInt32("energy", (int)senergy);

                TempData["Msg"] = "You worked Turtledachi, energy: -5 and meals = +" + k;

            } else {

                TempData["Msg"] = "Poor Turtle dachi no work, not enoungh energy points";
            }
            
            return RedirectToAction("Index"); 
        }  

        [HttpGet]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            int? sfull = HttpContext.Session.GetInt32("full");
            int? shappy = HttpContext.Session.GetInt32("happy");
            int? senergy = HttpContext.Session.GetInt32("energy");
            
            if (sfull >= 5 && shappy >= 5) {

                sfull -= 5;
                shappy -= 5;
                senergy += 15;

                HttpContext.Session.SetInt32("full", (int)sfull);
                HttpContext.Session.SetInt32("happy", (int)shappy);
                HttpContext.Session.SetInt32("energy", (int)senergy);
                
                TempData["Msg"] = "You Turtledachi slept, energy: +15, fullness: -5, and happiness: -5";

            } else {

                TempData["Msg"] = "Poor Turtledachi didn't sleep, not enoungh fullness or happiness points";
            }
            return RedirectToAction("Index"); 
        }  

    }
}