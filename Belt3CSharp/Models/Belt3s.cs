using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt3CSharp.Models
{
    public class Belt3 : BaseEntity
    {
        [Key]
        public int Belt3Id { get; set; }
        public string Belt3stg1 { get; set; }
        public string Belt3stg2 { get; set; }
        public string Belt3stg3 { get; set; }
        public string Belt3stg4 { get; set; }
        public string Belt3stg5 { get; set; }
        public int Belt3int1 { get; set; }
        public int Belt3int2 { get; set; }
        public DateTime Belt3date {get; set; }

        public int UserId { get; set; } //User Foreign key
        public User User { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
       
       
        public List<MtoM> MtoMs {get;set;} //Many to Many List

        public Belt3 () 
        {
            MtoMs = new List<MtoM>();
            
        }
        
    }
}
