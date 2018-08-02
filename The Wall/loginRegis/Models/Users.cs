using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DbConnection;


namespace loginRegis.Models
{
    
    public class Regis : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string FName { get; set; }

        [Required]
        [MinLength(2)]
        public string LName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
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