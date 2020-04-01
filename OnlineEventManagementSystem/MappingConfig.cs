using AutoMapper;
using OnlineEventManagementSystem.Entity;
using OnlineEventManagementSystem.Models;

namespace OnlineEventManagementSystem
{
    public class MappingConfig
    {
        public static void MapAccountDetails()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SignUpModel, Account>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src =>"User"));
                config.CreateMap<EventModel, Event>();
                config.CreateMap<ServiceModel, Service>();
                config.CreateMap<ServiceCategoryModel, ServiceCategory>();
            });
        }
    }
}