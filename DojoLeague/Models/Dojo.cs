using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
 
namespace DojoLeague.Models
{
    public class Dojo: BaseEntity
    {
        public Dojo() {
            ninjas = new List<Ninja>();
        }
 
        [Key]
        public long id { get; set; }
 
        [Required]
        public string Name { get; set; }
 
        [Required]
        public string Location { get; set; }

        [Required]
        public string Add_Info { get; set; }
 
        public ICollection<Ninja> ninjas { get; set; }
    }
}