﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GigHub.Models;

namespace GigHub.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        public UserDto Artist { get; set; }                
        public DateTime DateTime { get; set; }                
        public string Venue { get; set; }        
        public GenreDto Genre { get; set; }
                
    }
}