using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.API
{
    
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<NotificationDto> Notifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .Select(n => n.Notification)     
                .Include(n => n.Gig.Artist)
                .ToList();
        
            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead(IEnumerable<NotificationDto> notifications)
        {                        
            /*foreach (var item in notifications)
            {
                //_context.UserNotifications.ToList().Find(un => un.NotificationId == item. && !un.IsRead).IsRead = true;
            }*/

            return Ok();

        }
    }

    
}
