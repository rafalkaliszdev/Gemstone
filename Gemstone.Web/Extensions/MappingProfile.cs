using AutoMapper;
using Gemstone.Core.DomainModels;
using Gemstone.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gemstone.Web.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Assignor, LoginModel>().ReverseMap();

            CreateMap<Specialist, LoginModel>().ReverseMap();

            // RegisterModel does not require mapping

            CreateMap<Specialist, SpecialistModel>()
                .ForMember(dest => dest.Name, option => option.MapFrom(src => src.Username))
                .ReverseMap();

            CreateMap<DirectAssignmentModel, Assignment>()
                .Ignore(m => m.notAssignorID)
                .Ignore(m => m.notSpecialistID)
                .Ignore(m => m.AddedOn)
                .Ignore(m => m.AssignmentStatus)
                .Ignore(m => m.Assignor)
                .Ignore(m => m.Specialist)
                .Ignore(m => m.ID);

        }
    }
}