using AutoMapper;
using CourseLibrary.API.Entities;
using CouuseLibrary.API.Helpers;
using CouuseLibrary.API.Models;

namespace CouuseLibrary.API.Profiles
{
    public class AuthorsProfile : Profile
    {
        // Dizemos ao auto mapper como ele deve mapear nossas entidades e DTOs
        public AuthorsProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

            CreateMap<AuthorForCreationDto, Author>();
        }
    }
}
