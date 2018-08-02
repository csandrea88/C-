using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
// my using statements
//using System.Linq;
using loginRegis.Models;
// using loginRegis.ActionFilters;
// using Microsoft.AspNetCore.Mvc.ModelBinding;
// using Newtonsoft.Json;
//using Microsoft.EntityFrameworkCore;
using DbConnection;

namespace loginRegis.Controllers
{
    public class WallControllers : Controller
    {
        [HttpGet]
        [Route("Wall")]
        public IActionResult Wall()
        {
            

            ViewBag.LoggedInFName = HttpContext.Session.GetString("FName");

            string msgquery = "SELECT Messages.id, Messages.Message, Messages.Created_On,User.First_Name, User.Last_Name FROM Messages LEFT JOIN User ON Messages.User_id=User.id ORDER BY Messages.Created_On ASC;";  
            ViewBag.Messages = DbConnector.Query(msgquery);

            string cmtquery = "SELECT message_id, Comments.comment, Comments.created_On, User.First_Name, User.Last_Name FROM Comments LEFT JOIN Messages ON Comments.message_id = Messages.id LEFT JOIN User ON Comments.User_Id = User.id ORDER BY Comments.created_On ASC;";
            ViewBag.Comments = DbConnector.Query(cmtquery);

            
            return View("Wall");
        }
        
        [HttpPost]
        [Route("insmsg")]
        public IActionResult Insmsg(string message)
        {
            
                    
            int? LoggedInUserid = HttpContext.Session.GetInt32("userid");
            
            string query ="INSERT INTO MESSAGES (User_Id, Message, Updated_On, Created_On) VALUES (" + LoggedInUserid + ", '" + message + "', NOW(), NOW());";
            
            DbConnector.Execute(query); 
            
            return RedirectToAction("Wall");
                
        }
           
        

        [HttpPost]
        [Route("inscmt")]
        public IActionResult Inscmt(int msgid, string message)
        {
            int? LoggedInUserid = HttpContext.Session.GetInt32("userid");
            
            string query ="INSERT INTO COMMENTS (message_id, user_id, Comment, updated_On, created_On) VALUES (" + msgid + ", " + LoggedInUserid + ", '" + message + "', NOW(), NOW());";
            DbConnector.Execute(query); 
            
             return RedirectToAction("Wall");
       
        }


    }
}