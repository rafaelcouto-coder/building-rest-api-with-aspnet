using AutoMapper;
using CourseLibrary.API.Entities;
using CouuseLibrary.API.Models;

namespace CouuseLibrary.API.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseForCreationDto, Course>();
            CreateMap<CourseForUpdateDto, Course>();
            CreateMap<Course, CourseForUpdateDto>();
        }
    }
}
