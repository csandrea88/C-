using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace CallingCard.Controllers
{
    public class HelloControllers : Controller
    {
 
        // // A GET method
        // [HttpGet]
        // [Route("index")]
        // public string Index()
        // {
        //     return "Hello World!";
        // }
        
        // // A POST method
        // [HttpPost]
        // [Route("")]
        //  public string Index()
        // {
        //     return "Hello World!";
        // }

        [HttpGet]
        [Route("/{iFName}/{iLName}/{iAge}/{iFavColor}")]
        public JsonResult DisplayInt(string iFName,string iLName,string iAge, string iFavColor)
        {
            var AnonObject = new {
                                FirstName = iFName,
                                LastName = iLName,
                                Age = iAge,
                                FavoriteColor = iFavColor
                            };
            return Json(AnonObject);
        }
    }
}