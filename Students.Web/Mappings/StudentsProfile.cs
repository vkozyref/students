using System;
using AutoMapper;
using Students.Web.Entities;
using Students.Web.ViewModel;

namespace Students.Web.Mappings
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
