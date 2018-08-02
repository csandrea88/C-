using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace DojoLeague.Models
{
    public class Ninja : BaseEntity
    {
        [Key]
        public long id { get; set; }
 
        [Required]
        public string Name { get; set; }
 
        [Required]
        [Range(1,10)]
        public string Level { get; set; }

        public string Descrip { get; set; }
  
        public Dojo dojo { get; set; }
    }
}
