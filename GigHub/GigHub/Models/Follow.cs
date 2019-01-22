using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace GigHub.Models
{
    public class Follow
    {                
        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string FollowedId { get; set; }
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followed { get; set; }
        
    }

}