using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}