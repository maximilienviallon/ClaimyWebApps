using AutoMapper;
using ClaimyWebApps.Dtos;
using ClaimyWebApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // domain to DTo
            Mapper.CreateMap<Claim, ClaimDto>();
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<ZipCity, ZipCityDto>();

            //Dto to Domain 
            Mapper.CreateMap<ClaimDto, Claim>().ForMember(c => c.ID, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<ZipCityDto, ZipCity>();
        }


    }
}