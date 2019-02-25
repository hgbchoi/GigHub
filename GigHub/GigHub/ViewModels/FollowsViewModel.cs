using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class FollowsViewModel
    {
        public IEnumerable<ApplicationUser> Followed { get; set; }        
        public string Heading { get; set; }
    }
}