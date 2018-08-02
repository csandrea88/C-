using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt2CSharp.Models
{

    public class Regis : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Must be non-numeric charachters")]
        public string FName { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Must be non-numeric charachters")]
        public string LName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"(?!.*\.\.)(^[^\.][^@\s]+@[^@\s]+\.[^@\s\.]+$)", ErrorMessage = "Invalid: Must be a valid email")]
        public string Email { get; set; }
        
        // [Required]
        // public string Userstrg1  { get; set; }
        // [Required]
        // public int Userint1  { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        //[RegularExpression(@"(?=.*[A-Z][a-z])(?=.*\D)", ErrorMessage = "Must have one letter, one number and 1 special charachter")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match")]        
        public string CPassword { get; set; }

    }
    public class Login : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }  

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

    }  


}