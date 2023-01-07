using ApplicationLayer.DTO;
using AutoMapper;
using DataAccessLayer.Model;

namespace ApplicationLayer.Map
{
    public class MappintProfiles : Profile
    {
        public MappintProfiles()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<CourseDto, Course>();
        }
    }
}
