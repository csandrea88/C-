using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt2CSharp.Models
{
    public class Post : BaseEntity
    {
        [Key]
        public int PostId { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
       
       
        public List<Like> Likes {get;set;} 

        public Post () 
        {
            Likes = new List<Like>();
            
        }

    }

}