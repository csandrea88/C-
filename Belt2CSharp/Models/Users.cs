using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt2CSharp.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Userstrg1 {get; set; }
        public int Userint1 {get; set; }
        public string Password { get; set; } 

        public List<Like> Likes {get;set;}  
        public List<Post> Posts {get;set;}  


        public User() {
            Likes = new List <Like>();
            Posts = new List <Post>();
        } 

        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

         
        
    }
}