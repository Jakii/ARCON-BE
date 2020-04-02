using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Data;
using ArconApi.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Users.UserProfiles
{
    public class UserProfileAppService : IDisposable
    {
        private readonly IGenericRepository<UserProfile> _userProfileRepository;
        private readonly IMapper _mapper;
        public UserProfileAppService(IGenericRepository<UserProfile> userProfileRepository,IMapper mapper)
        {
            this._userProfileRepository = userProfileRepository;
            this._mapper = mapper;
        }

        public async Task<Response> GetAll()
        {
            IEnumerable<UserProfile> userProfile = await _userProfileRepository.GetAllAsyn();
           if(userProfile!=null && userProfile.Any())
           {
                return new Response { Data =  _mapper.Map<IEnumerable<UserProfileDto>>(userProfile)
                 };
           }else 
           {
               return new Response{ Message="La lista de perfiles de usuarios esta vacia"};
           }
        }

        public async Task<ActionResult<Response>> Create(UserProfileDto request)
        {
            UserProfile newUserProfile= new UserProfile.Builder(request.Name, request.RolId, request.IsActive, request.UserAppId)
            .Build();
            await _userProfileRepository.AddAsyn(newUserProfile);
            await _userProfileRepository.SaveAsync();
            return new Response { Data = _mapper.Map<UserProfileDto>(newUserProfile) };
        }

        public async Task<Response> Update(int id, UserProfileDto request)
        {
            UserProfile userProfileFound = await _userProfileRepository.GetAsync(id);
            if (userProfileFound == null)
            {
                return new Response { Message = " No existe usuario con el Id: " + id};
            }

           userProfileFound.SetName(request.Name);
           userProfileFound.SetRolId(request.RolId);
           userProfileFound.SetUser(request.UserAppId);
           userProfileFound.SetIsActive(request.IsActive);
           
            await _userProfileRepository.SaveAsync();

            return new Response { Data = _mapper.Map<UserProfileDto>(userProfileFound) };
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                
                _userProfileRepository.Dispose();
            }
        }
        
    }
}