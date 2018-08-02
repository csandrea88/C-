using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class WedPlanr : BaseEntity
    {
        [Key]
        public int WPId { get; set; }
        public int Userid {get;set;}
        public string WedderOne { get; set; }
        public string WedderTwo { get; set; }
        public DateTime WeddDate { get; set; }
        public string Address { get; set; }
        public List<RSVP> Users {get; set;}

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public WedPlanr ()
        {
            Users = new List <RSVP>();
        }
       
    }
}
