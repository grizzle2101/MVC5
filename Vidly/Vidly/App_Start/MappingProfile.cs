using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    //Task 2 - Create Customer & CustomerDTO Mapping.
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();

            //Movie Mappings
            Mapper.CreateMap<Movie, MovieDTO>()
                .ForMember(c => c.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<MovieDTO, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore()); ;
        }
    }
}