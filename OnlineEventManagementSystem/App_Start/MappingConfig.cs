using AutoMapper;
using OnlineEventManagementSystem.BL;
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
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => Roles.User.ToString()))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => new AccountBL().GenerateUserID()));
                config.CreateMap<EventModel, Event>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => new EventBL().GenerateEventID()));
                config.CreateMap<ServiceModel, Service>()
                .ForMember(dest => dest.ServiceID, opt => opt.MapFrom(src => new ServiceBL().GenerateServiceID()));
                config.CreateMap<ServiceCategoryModel, ServiceCategory>()
                .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => new ServiceCategoryBL().GenerateCategoryID()));
                config.CreateMap<PackageModel, Package>()
                .ForMember(dest => dest.PackageID, opt => opt.MapFrom(src => new PackageBL().GeneratePackageID()));
            });
        }
    }
}