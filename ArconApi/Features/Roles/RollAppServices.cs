using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Data;
using ArconApi.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Roles
{
    public class RollAppServices : IDisposable
    {
        private readonly IGenericRepository<Rol> _rolRepository;
        private readonly IMapper _mapper;
        public RollAppServices(IGenericRepository<Rol> rolRepository,IMapper mapper)
        {
            this._rolRepository = rolRepository;
            this._mapper = mapper;
        }

        public async Task<Response> GetAll()
        {
            IEnumerable<Rol> rolObj = await _rolRepository.GetAllAsyn();
           if(rolObj!=null && rolObj.Any())
           {
                return new Response { Data =  _mapper.Map<IEnumerable<RollDto>>(rolObj)
                 };
           }else 
           {
               return new Response{ Message="La lista de perfiles de usuarios esta vacia"};
           }
        }

        public async Task<ActionResult<Response>> Create(RollDto request)
        {
            Rol newRoll= new Rol.Builder(request.Name)
            .Build();
            await _rolRepository.AddAsyn(newRoll);
            await _rolRepository.SaveAsync();
            return new Response { Data = _mapper.Map<RollDto>(newRoll) };
        }

        public async Task<Response> Update(int id, RollDto request)
        {
            Rol rollFound = await _rolRepository.GetAsync(id);
            if (rollFound == null)
            {
                return new Response { Message = " No existe rol con el Id: " + id};
            }

           rollFound.SetName(request.Name);
           
            await _rolRepository.SaveAsync();

            return new Response { Data = _mapper.Map<RollDto>(rollFound) };
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
                
                _rolRepository.Dispose();
            }
        }
    }
}