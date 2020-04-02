using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Data;
using ArconApi.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Statuses
{
    public class StatusAppServices : IDisposable
    {
        private readonly IGenericRepository<Status> _statusRepository;
        private readonly IMapper _mapper;
        public StatusAppServices(IGenericRepository<Status> statusRepository,IMapper mapper)
        {
            this._statusRepository = statusRepository;
            this._mapper = mapper;
        }

        public async Task<Response> GetAll()
        {
            IEnumerable<Status> statusObj = await _statusRepository.GetAllAsyn();
           if(statusObj!=null && statusObj.Any())
           {
                return new Response { Data =  _mapper.Map<IEnumerable<StatusDto>>(statusObj)
                 };
           }else 
           {
               return new Response{ Message="La lista de perfiles de usuarios esta vacia"};
           }
        }

        public async Task<ActionResult<Response>> Create(StatusDto request)
        {
            Status newStatus= new Status.Builder(request.StatusName, request.Description)
            .Build();
            await _statusRepository.AddAsyn(newStatus);
            await _statusRepository.SaveAsync();
            return new Response { Data = _mapper.Map<StatusDto>(newStatus) };
        }

        public async Task<Response> Update(int id, StatusDto request)
        {
            Status statusFound = await _statusRepository.GetAsync(id);
            if (statusFound == null)
            {
                return new Response { Message = " No existe status con el Id: " + id};
            }

           statusFound.SetStatusName(request.StatusName);
           statusFound.SetDescription(request.Description);
           
            await _statusRepository.SaveAsync();

            return new Response { Data = _mapper.Map<StatusDto>(statusFound) };
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
                
                _statusRepository.Dispose();
            }
        }

    }
}