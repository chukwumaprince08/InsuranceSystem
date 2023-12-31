﻿using AutoMapper;
using InsuranceSystem.Core.Dtos;
using InsuranceSystem.Domain.Claims;
using InsuranceSystem.Domain.Policy;

namespace InsuranceSystem.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PolicyHolderDto, PolicyHolder>().ReverseMap();
                config.CreateMap<ClaimsDto, Claim>().ReverseMap();
                config.CreateMap<ClaimsResponseDto, Claim>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}

