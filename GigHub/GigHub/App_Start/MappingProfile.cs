﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Notification, NotificationDto>();
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Gig, GigDto>();
        }
    }
}