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
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => Account.GenerateUserID(src.UserFirstName, src.UserMobileNumber)))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src =>"User"));
                config.CreateMap<EventModel, Event>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => Event.GenerateEventID(src.EventName, src.EventType)));
                config.CreateMap<ServiceModel, Service>()
                .ForMember(dest => dest.ServiceID, opt => opt.MapFrom(src => Service.GenerateServiceID(src.ServiceName,src.ServiceCategory)));
            });
        }
    }
}