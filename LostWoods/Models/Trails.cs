using System.ComponentModel.DataAnnotations;

namespace LostWoods.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        public string Name { get; set; }
 
        [Required]
        [MinLength(10)]
        public string Descrip { get; set; }
         
        [Required]
        //[DataType(DataType.double)]
        public double Length { get; set; }

        [Required]
        public int ElevChg { get; set; }

        [Required]
        public int Longitude { get; set; }

        [Required]
        public int Latitude { get; set; }
        
    }
}
