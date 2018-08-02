using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt1CSharp.Models
{
    public class Participant : BaseEntity
    {
        public int ParticipantId {get; set;}
        public int Userid {get; set;}
        public User User {get;set;}
        //[ForeignKey("WedPlanr")]
        public int ActivityId {get; set;}
        public Activity Activity {get; set;}
        
        public DateTime Created_At {get; set;}
        public DateTime Updated_At {get; set;}
    }
}
