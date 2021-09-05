using Core.Models;
using Infrastructure.DTOs.StudentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WebApi.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentReadDTO>();

            CreateMap<StudentCreateDTO, Student>();

            CreateMap<StudentUpdateDTO, Student>();

            CreateMap<Student, StudentUpdateDTO>();
        }
        
    }
}
