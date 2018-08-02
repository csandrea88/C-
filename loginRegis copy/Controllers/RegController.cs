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
    public class RegController : Controller
    {
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            ViewBag.errors = "";
            return View("Register");
        }
        
        [HttpPost]
        [Route("processreg")]
        
        public IActionResult Processreg(Regis newregis)
        {
            ViewBag.errors = "";
            TryValidateModel(newregis);
            if(ModelState.IsValid) {
                
                List<Dictionary<string, object>> Users = DbConnector.Query("SELECT * FROM User Where Email = '" + newregis.Email + "' ;");
                
                if (Users.Count == 0) {
                   
                    string query = "INSERT INTO User (First_Name, Last_Name, Email, Password, Updated_On, Created_On) VALUES ('" + newregis.FName + "', '" + newregis.LName + "', '" + newregis.Email + "', '" + newregis.Password + "' ,NOW(), NOW());";
                    
                    DbConnector.Execute(query); 

                    ViewBag.errors = "Successfully Registered";
                                 
                    List<Dictionary<string, object>> SessUser = DbConnector.Query("SELECT * FROM User Where Email = '" + newregis.Email + "' ;");
                    
                    HttpContext.Session.SetInt32("userid", (int)SessUser[0]["id"]);
                    //HttpContext.Session.SetInt32("userid", SessUser[0]["id"]);(SessUser[0]["id"]);

                    return View("Register");

                    

                } else { 

                    ViewBag.errors = "Email already registered";
                    return View("Register");
                    
                }

            } else {
                //ViewBag.errors = ModelState.Values;
                return View("Register");
            }
            
        }



    }
}
