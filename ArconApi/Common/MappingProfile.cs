using AutoMapper;
using ArconApi.Feature.Category;
using ArconApi.Features.Users.UsersApps;
using ArconApi.Data.Models;
namespace ArconApi.Common
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<UserApp, UserAppDto>();
        }
    }
}