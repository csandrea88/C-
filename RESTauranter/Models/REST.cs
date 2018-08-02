using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RESTauranter.Models
{
    public class REST : BaseEntity
    {
        [Key]
        public int id_Rest { get; set; } 

        [Required]
        public string Rev_Name { get; set; }

        
        [Required]
        public string REST_Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Review { get; set; }

        [Required]
        [DateValid(ErrorMessage = "Date cannot be in the future")]
        public DateTime VisitDate { get; set; }

        [Required]
        public int Stars { get; set; }

        public class DateValidAttribute : ValidationAttribute
        {
            public override bool IsValid(object userdate)
            {
                return userdate != null && (DateTime)userdate < DateTime.Now;
            }
        }

    }
}
