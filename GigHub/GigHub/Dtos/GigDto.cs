using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GigHub.Models;
using Newtonsoft.Json;

namespace GigHub.Dtos
{
    public class GigDto
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public bool IsCanceled { get; set; }
        [JsonProperty]
        public UserDto Artist { get; set; }
        [JsonProperty]
        public DateTime DateTime { get; set; }
        [JsonProperty]
        public string Venue { get; set; }
        [JsonProperty]
        public GenreDto Genre { get; set; }
                
    }
}