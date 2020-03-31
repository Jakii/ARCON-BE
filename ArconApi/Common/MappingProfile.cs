using AutoMapper;
using ArconApi.Feature.Category;
using ArconApi.Data.Models;
namespace ArconApi.Common
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}