﻿using AutoMapper;
using tmss.Authorization.Users;
using tmss.Dto;

namespace tmss.Startup
{
    public static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserDto>()
                .ForMember(dto => dto.Roles, options => options.Ignore());
        }
    }
}