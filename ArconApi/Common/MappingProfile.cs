using AutoMapper;
using ArconApi.Feature.Category;
using ArconApi.Features.Users.UsersApps;
using ArconApi.Features.Users.UserProfiles;
using ArconApi.Data.Models;
using ArconApi.Feature.Activities;
using ArconApi.Features.Goals;
using ArconApi.Features.Roles;
using ArconApi.Features.Statuses;

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
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<Rol, RollDto>();
            CreateMap<Status, StatusDto>();
        }
    }
}