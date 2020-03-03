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
                config.CreateMap<SignUpViewModel, Account>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => Account.GenerateUserID(src.UserFirstName, src.UserMobileNumber)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src =>"User"));
            });
        }
    }
}