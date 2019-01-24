using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;

namespace GigHub.Controllers
{     
    [System.Web.Mvc.Authorize]
    public class FollowsController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Follow(FollowDto dto)
        {
            var userId = User.Identity.GetUserId();
            var follow = new Follow
            {
                FollowedId = dto.Followed,
                FollowerId = userId
            };
            if (_context.Follows.Any(f => f.FollowedId == dto.Followed && f.FollowerId == userId))
                return BadRequest("Already Following");
            _context.Follows.Add(follow);
            _context.SaveChanges();
            return Ok();

        }
    }
}
