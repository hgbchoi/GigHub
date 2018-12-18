using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public ApplicationUser Artist { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [MaxLength(255)]
        public string Venue { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }        
    }
}