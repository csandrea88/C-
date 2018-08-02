using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BankAccts.Models
{
    public class BAcc : BaseEntity
    {
        [Key]
        public int BAccId { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; } 

    }
}
