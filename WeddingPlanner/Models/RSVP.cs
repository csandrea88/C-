using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WeddingPlanner.Models
{
    public class RSVP : BaseEntity
    {
        public int rsvpid {get; set;}
        //public bool rsvp {get; set;}
        [ForeignKey("User")]
        public int UserId {get; set;}
        
        public User User {get;set;}
        [ForeignKey("WedPlanr")]
        public int WedplanrId {get; set;}
        public WedPlanr WedPlanr {get; set;}
        
        public DateTime Created_At {get; set;}
        public DateTime Updated_At {get; set;}

        


    }
}