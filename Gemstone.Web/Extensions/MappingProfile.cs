using AutoMapper;
using Gemstone.Core.DomainModels;
using Gemstone.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gemstone.Web.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Assignor, LoginModel>();
            CreateMap<LoginModel, Assignor>();
        }
    }
}
