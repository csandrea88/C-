using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
using System.Linq;
using Belt3CSharp.Models;
using Belt3CSharp.Factory;
using Belt3CSharp.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace Belt3CSharp.Controllers
{
    public class HomeController : Controller
    {
 
        // Entity PostGres Code First connection
        private Belt3CSharpContext _context;

        public HomeController(Belt3CSharpContext context)
        {
            // Dapper framework connections
            // _dbConnector = connect;
            // userFactory = new UserFactory();

            // Entity Framework connections
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("Home")]
        [ImportModelState]
        public IActionResult Home()
        {
             string fname = HttpContext.Session.GetString("FName");
             ViewBag.FName = fname;

            int? userid = HttpContext.Session.GetInt32("userid");
            ViewBag.sessuserid = userid;

            User user = _context.Users.SingleOrDefault (s => s.UserId == userid);
           
            if (user != null) {
                ViewBag.sessUserwallet = user.Userint1;    
            } else {
                ViewBag.sessUserwallet = 0;
            }

            List <Belt3> Belt3s = _context.Belt3s
                        .Include(Belt3 => Belt3.MtoMs)
                        .Include(U=>U.User)
                        .OrderBy(Belt3=>Belt3.Belt3int2)
                        //.OrderByDescending(Belt3=>Belt3.MtoMs.Count)
                        .ToList();
                        
                
          

            ViewBag.Belt3s = Belt3s;
            
            return View("Home");

        }

        [HttpGet]
        [Route("belt3Form/{belt3id}")]
        [ImportModelState]
        public IActionResult Belt3Formid(int belt3id)
        {
            string fname = HttpContext.Session.GetString("FName");
            ViewBag.FName = fname;

            int? userid = HttpContext.Session.GetInt32("userid");
            ViewBag.sessuserid = userid;

            return View("Belt3UpdtForm");
        }

        [HttpGet]
        [Route("addbelt3Form")]
        [ImportModelState]
        public IActionResult Belt3Form()
        {
            string fname = HttpContext.Session.GetString("FName");
            ViewBag.FName = fname;

            int? userid = HttpContext.Session.GetInt32("userid");
            ViewBag.sessuserid = userid;
            
            return View("Belt3AddForm");
        }

        [HttpPost]
        [Route("addBelt3")]
        [ImportModelState]
        public IActionResult AddBelt3(Belt3Val NewBelt3)
        {
            
            string fname = HttpContext.Session.GetString("FName");
            ViewBag.FName = fname;

            int? userid = HttpContext.Session.GetInt32("userid");
            ViewBag.sessuserid = userid;
             
            
            TryValidateModel(NewBelt3);
            if(ModelState.IsValid) {
                Belt3 InsBelt3 = new Belt3
                {
                    UserId = (int)userid,
                    Belt3stg1 = NewBelt3.Belt3stg1,
                    Belt3stg2 = NewBelt3.Belt3stg2,                   
                    
                    Belt3int1 = NewBelt3.Belt3int1,
                    Belt3int2 = 0,
                    
                    Belt3date = NewBelt3.Belt3date,

                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now
                };

                _context.Add(InsBelt3);
                _context.SaveChanges(); 

                return RedirectToAction ("Home");
            } else {
                return View("Belt3AddForm");
            }

        }

        [HttpPost]
        [Route("addBelt3small")]
        [ImportModelState]
        public IActionResult AddBelt3small(Belt3Valsmall NewBelt3Valsmall)
        {
            
            string fname = HttpContext.Session.GetString("FName");
            ViewBag.FName = fname;

            int? userid = HttpContext.Session.GetInt32("userid");
            ViewBag.sessuserid = userid;
             
            
            TryValidateModel(NewBelt3Valsmall);
            if(ModelState.IsValid) {
                Belt3 InsBelt3small = new Belt3
                {
                    UserId = (int)userid,
                    Belt3stg1 = NewBelt3Valsmall.Belt3stg1s,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now
                };

                _context.Add(InsBelt3small);
                _context.SaveChanges(); 

                return RedirectToAction ("Home");
            } else {
                TempData["Belt3Valsmall"] = "Add failed, this field is required";
                return RedirectToAction ("Home");
            }

        }

        [HttpGet]
        [Route("deleteBelt3/{Belt3id}")]
        [ImportModelState]
        public IActionResult DeleteBelt3 (int Belt3id)
        {
            Belt3 deleteBelt3 = _context.Belt3s.SingleOrDefault (a=>a.Belt3Id == Belt3id);
           
            _context.Remove(deleteBelt3);
            _context.SaveChanges();

            return RedirectToAction ("Home");
        }
        

        [HttpPost]
        [Route("addMtoM/{Belt3id}/{Maxbid}")]
        [ImportModelState]
        public IActionResult addMtoM (int Belt3id, int BidAmt, int Maxbid)
        {
            int? UserId = HttpContext.Session.GetInt32("userid"); 

            User user = _context.Users.SingleOrDefault (s => s.UserId == UserId);
           
            if (user != null) {
                ViewBag.sessUserwallet = user.Userint1;    
            } else {
                ViewBag.sessUserwallet = 0;
            }

            if (BidAmt < ViewBag.sessUserwallet && BidAmt > Maxbid) {
                
                MtoM AddMtoM = new MtoM {
                    Userid = (int)UserId,
                    Belt3Id = Belt3id,
                    BidAmt = BidAmt,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now
                };
                    
                    _context.Add(AddMtoM);
                    _context.SaveChanges();
        
                    return RedirectToAction ("Home");

            } else {

                TempData["error"] = "Bid Amount must be less than your wallet amount and greater than the maxbid";
                return RedirectToAction ("ShowBelt3", "Home", new {Belt3id = Belt3id});
            }

        }

        [HttpGet]
        [Route("delMtoM/{MtoMid}")]
        [ImportModelState]
        public IActionResult DelMtoM (int MtoMid)
        {
            int? UserId = HttpContext.Session.GetInt32("userid");

            MtoM DeleteMtoM = _context.MtoMs
                .Where(m => m.MtoMId == MtoMid)
                .SingleOrDefault();
           
            _context.Remove(DeleteMtoM);
            _context.SaveChanges();

            return RedirectToAction ("Home");       
        
        }

        
        [HttpGet]
        [Route("showUser/{Userid}")]
        [ImportModelState]
        public IActionResult ShowUser(int Userid)
        {
            string fname = HttpContext.Session.GetString("FName");
            ViewBag.FName = fname;

            int? userid = HttpContext.Session.GetInt32("userid");
            
            ViewBag.sessuserid = userid;       

           User User = _context.Users
                .Include(U=>U.MtoMs)
                .Include(Belt3 => Belt3.Belt3s)
                .Where(u=>u.UserId == Userid)
                .SingleOrDefault();

            ViewBag.User = User;

            return View("ShowUsers");

        }

        [HttpGet]
        [Route("showBelt3/{Belt3id}")]
        [ImportModelState]
        public IActionResult ShowBelt3(int Belt3id)
        {
            string fname = HttpContext.Session.GetString("FName");
            ViewBag.FName = fname;

            int? userid = HttpContext.Session.GetInt32("userid");
            ViewBag.sessuserid = userid;

            Belt3 Belt3 = _context.Belt3s
                .Include(B=>B.MtoMs)
                .ThenInclude(U=>U.User)
                .Where(B=>B.Belt3Id == Belt3id)
                .SingleOrDefault();

            ViewBag.Belt3 = Belt3;

            ViewBag.maxbid = 0;
            
            if (ViewBag.Belt3.MtoMs.Count > 0) {
                int maxbid = 0;
                ViewBag.Name = "";
                ViewBag.maxbid = 0;

                foreach (var MtoM in Belt3.MtoMs) {
                    if (MtoM.BidAmt > maxbid ) {
                        ViewBag.maxbid = MtoM.BidAmt;
                        ViewBag.Name = MtoM.User.FName + " " + MtoM.User.LName;
                    }    
                }
            }
            return View("ShowBelt3");

        }




    }
}
