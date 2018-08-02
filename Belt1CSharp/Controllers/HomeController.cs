using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
// my using statements
using System.Linq;
using Belt1CSharp.Models;
using Belt1CSharp.Factory;
using Belt1CSharp.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;



namespace Belt1CSharp.Controllers
{
    public class HomeController : Controller
    {
        // Entity PostGres Code First connection
        private Belt1CSharpContext _context;

        public HomeController(Belt1CSharpContext context)
        {
            // Entity Framework connections
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("home")]
        [ImportModelState]
        public IActionResult Home()
        {
            int? userid = HttpContext.Session.GetInt32("userid");
            ViewBag.sessuserid = userid;
            ViewBag.FName = HttpContext.Session.GetString("FName");
            
            List <Activity> Activities = _context.Activities
                        .Include(Activity=> Activity.Participants)
                        .ThenInclude(U=>U.User)
                        .Where(Activ=>Activ.Date >= DateTime.Now)
                        .OrderBy(Activity=>Activity.Date)
                        .ToList();

            ViewBag.Activities = Activities;
            return View("Home");
        }

        [HttpGet]
        [Route("activityDtls/home")]
        [ImportModelState]
        public IActionResult ActivityDtlsHome()
        {
            return RedirectToAction ("Home");
        }

        [HttpGet]
        [Route("activityDtls/logout")]
        [ImportModelState]
        public IActionResult ActivityDtlslogout()
        {
            return RedirectToAction ("Logout", "Login");
        }


        [HttpGet]
        [Route("activityDtls/addParticipant/{actid}")]
        [ImportModelState]
        public IActionResult DtlsAddParticipant(int actid)
        {
            return RedirectToAction ("AddParticipant", "Home", new {id = actid});
        }

        [HttpGet]
        [Route("activityDtls/deleteParticipant/{particid}")]
        [ImportModelState]
        public IActionResult DtlsDeleteParticipant(int particid)
        {
            return RedirectToAction ("deleteParticipant", "Home", new {id = particid});
        }
         
        [HttpGet]
        [Route("activityDtls/deleteActivity/{actid}")]
        [ImportModelState]
        public IActionResult DtlsDeleteActivity(int actid)
        {
            return RedirectToAction ("deleteActivity", "Home", new {id = actid});
        }
        
        [HttpGet]
        [Route("addActivity")]
        [ImportModelState]
        public IActionResult AddActivity()
        {
            int? userid = HttpContext.Session.GetInt32("userid");
            ViewBag.sessuserid = userid;
            ViewBag.FName = HttpContext.Session.GetString("FName");

            return View("ActivityAdd");
        }

        [HttpPost]
        [Route("activityDetails")]
        public IActionResult ActivityDetails (ActivityVal NewActivity)
        {
            ViewBag.errors ="";

            int? userid = HttpContext.Session.GetInt32("userid");
            ViewBag.sessuserid = userid;

            string fname = HttpContext.Session.GetString("FName");
            ViewBag.FName = fname;

            
            TryValidateModel(NewActivity);
            if(ModelState.IsValid) {
                Activity AddActivity = new Activity
                {
                    UserId = (int)userid,
                    Title = NewActivity.Title,
                    Time = NewActivity.Time,
                    Date = NewActivity.Date,
                    Duration = NewActivity.Duration,
                    DuratType = NewActivity.DuratType,
                    Descrip = NewActivity.Descrip,
                    EventCoordId = (int)userid,
                    EventCoordFName = fname,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Add(AddActivity);
                _context.SaveChanges(); 

                return RedirectToAction ("ActivityDtls", "Home", new {id = AddActivity.ActivityId});
            } else {
                return View("ActivityAdd");
            }
        }


        [HttpGet]
        [Route("activityDtls/{id}")]
        [ImportModelState]
        public IActionResult ActivityDtls (int id)
        {
            int? UserId = HttpContext.Session.GetInt32("userid"); 
            string fname = HttpContext.Session.GetString("FName");
            ViewBag.FName = fname;
            
            Activity CurrActivity = _context.Activities 
                        .Include(Act=> Act.Participants)
                        .ThenInclude(U=>U.User)
                        .Where(s => s.ActivityId == id)
                        .SingleOrDefault();

            ViewBag.CurrActivity = CurrActivity;
            ViewBag.sessuserid = UserId;
                       
            return View("ActivityDtls");
        }
        
        [HttpGet]
        [Route("deleteActivity/{id}")]
        [ImportModelState]
        public IActionResult DeleteActivity (int id)
        {
            Activity DeleteActivity = _context.Activities.SingleOrDefault (act=>act.ActivityId == id);
           
            _context.Remove(DeleteActivity);
            _context.SaveChanges();

            return RedirectToAction ("Home");
        }

        [HttpGet]
        [Route("addParticipant/{actid}")]
        [ImportModelState]
        public IActionResult AddParticipant (int actid)
        {
        int? UserId = HttpContext.Session.GetInt32("userid"); 
        
        Activity joinActivity = _context.Activities
            .Where(Activ=>Activ.ActivityId == actid) 
            .SingleOrDefault();

        Participant AddParticipant = new Participant {
            Userid = (int)UserId,
            ActivityId = actid,
            Created_At = DateTime.Now,
            Updated_At = DateTime.Now
           };
               
            _context.Add(AddParticipant);
            _context.SaveChanges();
 
            return RedirectToAction ("Home");

        }

        [HttpGet]
        [Route("deleteParticipant/{id}")]
        [ImportModelState]
        public IActionResult DeleteParticipant (int id)
        {
            int? UserId = HttpContext.Session.GetInt32("userid"); 
            Participant DeleteParticipant = _context.Participants
                .Where(act => act.ParticipantId == id)
                .SingleOrDefault();
           
            _context.Remove(DeleteParticipant);
            _context.SaveChanges();

            return RedirectToAction ("Home");       
        
        
        }

    }
}
