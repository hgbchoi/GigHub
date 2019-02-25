using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using GigHub.Dtos;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;

namespace GigHub.Controllers
{
    [System.Web.Http.Authorize]
    public class FollowingController : Controller
    {

        private readonly ApplicationDbContext _context;

        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new FollowsViewModel();
            viewModel.Followed = _context.Follows.Where(f => f.FollowerId == userId).Select(f => f.Followed);
            viewModel.Heading = "Followed Users";
            return View("Follows", viewModel);
        }

    }
}
