using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models.Movies
{
    public class CreateMovieModel
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Director { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}
