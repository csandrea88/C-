using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt3CSharp.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Userstrg1 {get; set; }
        public int Userint1 {get; set; }
        public string Password { get; set; } 

        public List<MtoM> MtoMs {get;set;}  
        public List<Belt3> Belt3s {get;set;}  


        public User() {
            MtoMs = new List <MtoM>();
            Belt3s = new List <Belt3>(); //Foreign Key setup
        } 

        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

         
        
    }
}