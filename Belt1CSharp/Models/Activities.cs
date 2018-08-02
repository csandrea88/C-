using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt1CSharp.Models
{
    public class Activity : BaseEntity
    {
        [Key]
        public int ActivityId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public string Title{ get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string DuratType { get; set; }  
        public string Descrip { get; set; } 
        public DateTime Date { get; set; } 

        public int EventCoordId { get; set; }
        public string EventCoordFName { get;set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        


        public List<Participant> Participants {get;set;} 

        public Activity () 
        {
            Participants = new List<Participant>();
        }

    }
}
