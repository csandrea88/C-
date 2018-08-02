using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
using System.Linq;
using Belt2CSharp.Models;
using Belt2CSharp.Factory;
using Belt2CSharp.ActionFilters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace Belt2CSharp.Controllers
{
    public class HomeController : Controller
    {
        // ########## ROUTES ##########
        //  /
        //  /(add_routes_guide)
        //  /
        // ########## ROUTES ##########

        // Dapper connections
        // private readonly UserFactory userFactory;
        // private readonly DbConnector _dbConnector;

        // Entity PostGres Code First connection
        private Belt2CSharpContext _context;

        public HomeController(Belt2CSharpContext context)
        {
            // Dapper framework connections
            // _dbConnector = connect;
            // userFactory = new UserFactory();

            // Entity Framework connections
            _context = context;
        }
        [HttpGet]
        [Route("userprof/Home")]
        [ImportModelState]
        public IActionResult UPHome()
        {
            return RedirectToAction ("Home", "Home");
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


            List <Post> Posts = _context.Posts
                        .Include(Post=> Post.Likes)
                        .Include(U=>U.User)
                        .OrderBy(Post=>Post.Likes.Count)
                        .ToList();

            ViewBag.Posts = Posts;
            
            return View("Home");
        }

        [HttpPost]
        [Route("addPost")]
        [ImportModelState]
        public IActionResult AddPost (string postmessage)
        {

            int? userid = HttpContext.Session.GetInt32("userid");
            
                Post AddPost = new Post
                {
                    UserId = (int)userid,
                    Message = postmessage,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now
                };

                _context.Add(AddPost);
                _context.SaveChanges(); 

            return RedirectToAction ("Home");
        }

        [HttpGet]
        [Route("addLike/{id}")]
        [ImportModelState]
        public IActionResult AddLike (int id)
        {

            int? userid = HttpContext.Session.GetInt32("userid");
            
                Like AddLike = new Like
                {
                    Userid = (int)userid,
                    PostId = id,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now
                };

                _context.Add(AddLike);
                _context.SaveChanges(); 

            return RedirectToAction ("Home");
        }
        [HttpGet]
        [Route("deletePost/{id}")]
        [ImportModelState]
        public IActionResult DeletePost (int id)
        {

            int? userid = HttpContext.Session.GetInt32("userid");
            
            Post DeletePost = _context.Posts
                .Where(p => p.PostId == id)
                .SingleOrDefault();

                _context.Remove(DeletePost);
                _context.SaveChanges(); 

            return RedirectToAction ("Home");
        }
        
        [HttpGet]
        [Route("userprof/{Id}")]
        [ImportModelState]
        public IActionResult Userprof (int Id)
        {

            int? userid = HttpContext.Session.GetInt32("userid");
            
            User Users = _context.Users
                .Where(user=>user.UserId == Id)
                .SingleOrDefault();

            ViewBag.Users = Users;

            return View ("User");
        }
        [HttpGet]
        [Route("likes/{Id}")]
        [ImportModelState]

        public IActionResult Likes (int Id)
        {

            int? userid = HttpContext.Session.GetInt32("userid");
            List <Post> Posts = _context.Posts
                        .Include(Post=> Post.Likes)
                        .Include(U=>U.User)
                        .Where(p=>p.PostId == Id)
                        .ToList();

        
            ViewBag.Posts = Posts;

            return View ("Likes");
        }

    }
}
