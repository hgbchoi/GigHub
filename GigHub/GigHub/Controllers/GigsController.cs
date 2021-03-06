﻿using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context
                .Gigs.Where(g => g.ArtistId == userId && g.DateTime > DateTime.Now && !g.IsCanceled)
                .Include(g => g.Genre)
                .ToList();                                                            
            return View(gigs);
        }
        
        public ActionResult Search(string searchString)
        {
            var viewModel = new GigsViewModel
            {
                Heading = "Upcoming Gigs",
                UpcomingGigs = _context.Gigs
                    .Where(g => !g.IsCanceled && (g.Artist.Name.Contains(searchString) 
                    || g.Genre.Name.Contains(searchString) 
                    || g.Venue.Contains(searchString)))
                    .Include(g => g.Artist).Include(g => g.Genre).ToList(),
                 SearchString = searchString
            };
            return View("Gigs", viewModel);
        }

        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Include(g => g.Artist).Include(g=>g.Attendances).Single(g => g.Id == id);                      
            var viewModel = new DetailsViewModel();
            viewModel.Gig = gig;            
            viewModel.IsGoing = gig.Attendances.Any(a => a.AttendeeId == userId);
            viewModel.IsFollowing = _context.Follows.Any(f => f.FollowedId == gig.ArtistId && f.FollowerId == userId);
            if (User.Identity.GetUserId() != null)
            {
                viewModel.ShowActions = true;
            }
            return View(viewModel);
        }


        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
            var viewModel = new GigsViewModel
            {
                UpcomingGigs = gigs,
                ShowActions = true,
                Heading = "Gigs I'm Attending"
            };            

            return View("Gigs", viewModel);
        }
        
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList(),
                Heading = "Create a Gig"                
            };
            return View("GigForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);
            var viewModel = new GigFormViewModel
            {                
                Id = id,
                Genres = _context.Genres.ToList(),
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Genre = gig.GenreId,
                Venue = gig.Venue,
                Heading = "Edit a Gig"
            };
            return View("GigForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Include(g => g.Attendances.Select(a => a.Attendee)).Single(g => g.Id == viewModel.Id && g.ArtistId == userId);
            gig.Update(viewModel.Venue, viewModel.GetDateTime(), viewModel.Genre);

            _context.SaveChanges();
            return RedirectToAction("Mine", "Gigs");
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("GigForm", viewModel);
            }
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Gigs");
        }
    }
}