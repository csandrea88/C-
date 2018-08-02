using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<RSVP> WedPlanrs { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User() 
        {
            WedPlanrs = new List<RSVP>();
        }

        
    }
}