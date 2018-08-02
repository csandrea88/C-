using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt2CSharp.Models
{
    public class Like : BaseEntity
    {

        public int LikeId { get; set; }
        public int Userid {get; set;}
        public User User {get;set;}
        public int PostId {get;set;}
        public Post Post {get;set;}
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}