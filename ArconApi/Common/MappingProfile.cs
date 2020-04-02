using AutoMapper;
using ArconApi.Feature.Category;
using ArconApi.Features.Users.UsersApps;
using ArconApi.Data.Models;
using ArconApi.Feature.Activities;
using ArconApi.Features.Goals;

namespace ArconApi.Common
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<UserApp, UserAppDto>();
            CreateMap<GoalActivity, GoalActivityDto>();
            CreateMap<Goal, GoalDto>();
        }
    }
}