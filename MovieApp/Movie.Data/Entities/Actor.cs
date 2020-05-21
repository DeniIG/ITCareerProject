using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Data.Entities
{

    [Table("Actors")]
    public class Actor
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Born { get; set; }

        public ICollection<MovieActor> Movies {get; set; }
    }
}
