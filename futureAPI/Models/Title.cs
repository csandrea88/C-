using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace futureAPI.Models
{
    public class Title : BaseEntity
    {
        public int ID {get; set;}
        public string title {get; set;}
    }
}