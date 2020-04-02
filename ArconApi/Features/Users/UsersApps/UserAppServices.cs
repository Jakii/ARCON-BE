using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Data;
using ArconApi.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Users.UsersApps
{
    public class UserAppServices : IDisposable
    {
        private readonly IGenericRepository<UserApp> _userAppRepository;
        private readonly IMapper _mapper;
        public UserAppServices(IGenericRepository<UserApp> userAppRepository,IMapper mapper)
        {
            this._userAppRepository=userAppRepository;
            this._mapper = mapper;
        }

        public async Task<Response> GetAll()
        {
            IEnumerable<UserApp> userApp = await _userAppRepository.GetAllAsyn();
           if(userApp!=null && userApp.Any())
           {
                return new Response { Data =  _mapper.Map<IEnumerable<UserAppDto>>(userApp)
                 };
           }else 
           {
               return new Response{ Message="La lista de Usuarios esta vacia"};
           }

        }

        public async Task<ActionResult<Response>> Create(UserAppDto request)
        {
            UserApp newUserApp= new UserApp.Builder(request.UserName, request.Name, request.IsActive)
            .WhithEmail(request.Email).WhithBirthDate(request.BirthDate)
            .Build();
            await _userAppRepository.AddAsyn(newUserApp);
            await _userAppRepository.SaveAsync();
            return new Response { Data = _mapper.Map<UserAppDto>(newUserApp) };
        }

        public async Task<Response> Update(int id, UserAppDto request)
        {
            UserApp userAppFound = await _userAppRepository.GetAsync(id);
            if (userAppFound == null)
            {
                return new Response { Message = " No existe usuario con el Id: " + id};
            }

           userAppFound.SetName(request.UserName);
           userAppFound.SetEmail(request.Email);
           userAppFound.SetBirthDate(request.BirthDate);
           userAppFound.SetIsActive(request.IsActive);
           
            await _userAppRepository.SaveAsync();

            return new Response { Data = _mapper.Map<UserAppDto>(userAppFound) };
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
                
                _userAppRepository.Dispose();
            }
        }

    }
    
}