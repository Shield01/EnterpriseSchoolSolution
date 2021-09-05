using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Infrastructure.DTOs.StaffDTOs;

namespace WebApi.Profiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<Staff, StaffReadDTO>();

            CreateMap<StaffCreateDTO, Staff>();

            CreateMap<StaffUpdateDTO, Staff>();

            CreateMap<Staff, StaffUpdateDTO>();
        }
    }
}
