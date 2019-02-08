using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GigHub.Models;
using Newtonsoft.Json;

namespace GigHub.Dtos
{
    public class NotificationDto
    {
        public int Id;
        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }
        [JsonProperty("type")]
        public NotificationType Type { get; set; }
        [JsonProperty("originalDateTime")]
        public DateTime? OriginalDateTime { get; set; }
        [JsonProperty("originalVenue")]
        public string OriginalVenue { get; set; }
        [JsonProperty("gig")]
        public GigDto Gig { get; set; }
    }
}