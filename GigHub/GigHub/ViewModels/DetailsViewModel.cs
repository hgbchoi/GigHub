using System;
using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class DetailsViewModel
    {
        public Gig Gig { get; set; } = new Gig();     
        public bool IsGoing { get; set; }
        public bool IsFollowing { get; set; }
        public bool ShowActions { get; set; }
    }
}