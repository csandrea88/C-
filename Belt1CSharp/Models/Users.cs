using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt1CSharp.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public List<Participant> Activities {get;set;}  
            
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User() {
            Activities = new List <Participant>();
        } 
        
    }
}