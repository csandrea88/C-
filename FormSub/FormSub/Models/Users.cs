using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FormSub.Models
{

    public class User : BaseEntity
    {  
        [Required]
        [MinLength(4)]
        public string FName { get; set; }

        [Required]
        [MinLength(4)]
        public string LName { get; set; }

        [Required]
        [Range(1,100)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
 
    }
    

}