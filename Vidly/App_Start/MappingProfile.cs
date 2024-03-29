﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;
using Vidly.Models.Dtos;

namespace Vidly.App_Start
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      //Domain to Dto
      Mapper.CreateMap<Customer, CustomerDto>();
      Mapper.CreateMap<Movie, MovieDto>();
      Mapper.CreateMap<MembershipType, MembershipTypeDto>();

      //Dto to Domain 
      Mapper.CreateMap<CustomerDto, Customer>();  
      Mapper.CreateMap<MovieDto, Movie>();
    }
  }
}