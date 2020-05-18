using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Genre { get; set; }

        public ICollection<MovieActor> Actors { get; set; }
    }
}
