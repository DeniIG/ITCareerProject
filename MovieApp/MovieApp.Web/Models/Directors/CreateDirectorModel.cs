using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models.Directors
{
    public class CreateDirectorModel
    {
            [Required]
            [StringLength(50, MinimumLength = 3)]
            public string Name { get; set; }

            [Required]
            public int Age { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3)]
            public string Country { get; set; }

        
    }
}
