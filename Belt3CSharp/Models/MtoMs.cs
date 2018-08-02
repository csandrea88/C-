using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt3CSharp.Models
{
    public class MtoM : BaseEntity
    {

        public int MtoMId { get; set; }
        public int Userid {get; set;}
        public User User {get;set;}
        public int Belt3Id {get;set;}
        public Belt3 Belt3 {get;set;}

        public int BidAmt {get;set;}
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

    }
}