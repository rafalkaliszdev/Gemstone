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

            CreateMap<Specialist, LoginModel>();
            CreateMap<LoginModel, Specialist>();

            // RegisterModel does not require mapping

            CreateMap<Specialist, SpecialistModel>()
                .ForMember(dest => dest.Name, option => option.MapFrom(src => src.Username));
            CreateMap<SpecialistModel, Specialist>()
                .ForMember(dest => dest.Username, option => option.MapFrom(src => src.Name));

            // todo implement this model
            //CreateMap<Assignor, AssignorModel>();
            //CreateMap<AssignorModel, Specialist>();
        }
    }
}
