using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt3CSharp.Models
{

    public class Belt3Val : BaseEntity
    {
        [Required(ErrorMessage = "This value is required")]
        [MinLength(3, ErrorMessage = "This value must have a minimum length of 3")]
        public string Belt3stg1 { get; set; }

        [Required(ErrorMessage = "This value is required")]
        [MinLength(10, ErrorMessage = "This value must have a minimum length of 10")]
        public string Belt3stg2 { get; set; }
                
        [Required(ErrorMessage = "This value is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int Belt3int1 { get; set; } 

        
        [Required(ErrorMessage = "This value is required")]
        [DateValid(ErrorMessage = "Date must be in the future")]
        public DateTime Belt3date { get; set; } 

        public class DateValidAttribute : ValidationAttribute
        {
            public override bool IsValid(object userdate)
            {
                return userdate != null && (DateTime)userdate > DateTime.Now;
            }
        }
    }
}