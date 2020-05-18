using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models.Actors
{
    public class CreateActorModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Born { get; set; }

    }
}
