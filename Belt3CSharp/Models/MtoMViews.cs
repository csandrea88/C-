using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Belt3CSharp.Models
{

    public class Belt3Valsmall : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Belt3stg1s { get; set; }

        
    }
}