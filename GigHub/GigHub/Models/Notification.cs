﻿using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Gig Gig { get; private set; }

        protected Notification()
        {

        }

        private Notification(NotificationType type, Gig gig)
        {
            if (gig == null)
                throw new ArgumentNullException("gig");

            DateTime = DateTime.Now;
            Type = type;
            Gig = gig;
        }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(NotificationType.GigCreated, gig);
        }

        public static Notification GigUpdated(Gig gig, DateTime originalDateTime, string originalVenue)
        {           
            var notification = new Notification(NotificationType.GigUpdated, gig);
            notification.OriginalVenue = originalVenue;
            notification.OriginalDateTime = originalDateTime;
            return notification;
        }
        public static Notification GigDeleted(Gig gig)
        {
            return new Notification(NotificationType.GigCanceled, gig);
        }
    }
}