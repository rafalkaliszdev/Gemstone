using AutoMapper;
using Gemstone.Core.DomainModels;
using Gemstone.Web.ViewModels;

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
                .ForMember(dest => dest.Assignments, option => option.MapFrom(src => src.Assignments))
                .ReverseMap();

            CreateMap<DirectAssignmentModel, Assignment>()
                .Ignore(m => m.AssignorID)
                .Ignore(m => m.SpecialistID)
                .Ignore(m => m.AddedOn)
                .Ignore(m => m.AssignmentStatus)
                .Ignore(m => m.Assignor)
                .Ignore(m => m.Specialist)
                .Ignore(m => m.ID);

            CreateMap<Assignment, ReadonlyAssignmentModel>()
                .ForMember(dest => dest.AssignorName, option => option.MapFrom(src => src.Assignor.Username))
                .Ignore(m => m.SpecialistID)
                .Ignore(m => m.SpecialistName);
        }
    }
}