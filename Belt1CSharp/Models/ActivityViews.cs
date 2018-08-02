using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt1CSharp.Models
{

    public class ActivityVal : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Title{ get; set; }

        [Required]
        public string Time { get; set; }
        
        [Required]
        [DateValid(ErrorMessage = "Date must be in the future")]
        public DateTime Date { get; set; } 
        
        [Required]
        public string Duration { get; set; }
       
        [Required]
        public string DuratType { get; set; }

        [Required]
        [MinLength(10)]
        public string Descrip { get; set; } 

        public class DateValidAttribute : ValidationAttribute
        {
            public override bool IsValid(object userdate)
            {
                return userdate != null && (DateTime)userdate > DateTime.Now;
            }
        }


    }


}