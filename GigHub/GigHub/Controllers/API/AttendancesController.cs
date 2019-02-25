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

namespace GigHub.Controllers
{    
    [Authorize]
    public class AttendancesController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();           
            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            if (_context.Attendances.Any(a => a.GigId == dto.GigId && a.AttendeeId == userId))            
                return BadRequest("Attendance already exists");            
            _context.Attendances.Add(attendance);
            _context.SaveChanges();            
            return Ok();
        }        
    }
}
