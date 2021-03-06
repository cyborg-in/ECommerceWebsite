﻿using AutoMapper;
using ECommerceWebsite.Models;
using ECommerceWebsite.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Order, OrderDto>();
            Mapper.CreateMap<OrderDto, Order>();
        }
    }
}