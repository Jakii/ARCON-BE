using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Data;
using ArconApi.Data.Models;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Feature.Activities
{
    public class ActivityAppServices : IDisposable
    {
        private readonly IGenericRepository<GoalActivity> _activityRepository;
        private readonly IMapper _mapper;

        public ActivityAppServices(IGenericRepository<GoalActivity> activityRepository,IMapper mapper)
        {
            _activityRepository=activityRepository;
            _mapper=mapper;
        }
       
        public async Task<ActionResult<Response>> Create(GoalActivityDto request)
        {
            GoalActivity goalActivity= new GoalActivity.Builder(request.Name).Build();
           
            await _activityRepository.AddAsyn(goalActivity);
            await _activityRepository.SaveAsync();
            return new Response { Data = _mapper.Map<GoalActivity>(goalActivity) };
        }
        public async Task<Response> GetAll()
        {
            IEnumerable<GoalActivity> goalActivities = await _activityRepository.GetAllAsyn();
           if(goalActivities!=null && goalActivities.Any())
           {
                return new Response { Data =  _mapper.Map<IEnumerable<GoalActivityDto>>(goalActivities)};
           }else 
           {
               return new Response{ Message="La lista de actividades esta vacia"};
           }
        }
        public async Task<Response> GetActivityById(int id)
        {
            GoalActivity goalActivityFind=await _activityRepository.GetAsync(id);
            if(goalActivityFind!=null)
            {
                return new Response {Data = _mapper.Map<GoalActivity, GoalActivityDto>(goalActivityFind)};
            }
            else
            {
                return new Response { Message=$"No se encontro actividad para el id:{id} "};
            }
        }
        public async Task<Response> Update(int id, GoalActivityDto request)
        {
            GoalActivity goalActivityFind = await _activityRepository.GetAsync(id);
            if (goalActivityFind == null)
            {
                return new Response {Message=$"No se encontro actividad para el id:{id} "};
            }

            goalActivityFind.SetName(request.Name);
            await _activityRepository.SaveAsync();
            return new Response { Data = _mapper.Map<GoalActivity>(goalActivityFind) };
        }
        public async Task<Response> Delete(int id)
        {
            GoalActivity goalActivityFind = await _activityRepository.GetAsync(id);
            if (goalActivityFind == null)
            {
                return new Response {Message=$"No se encontro actividad para el id:{id} "};
            }
            else
            {
                var value=await _activityRepository.DeleteAsyn(goalActivityFind);
                if(value>0)
                {
                    await _activityRepository.SaveAsync();
                    return new Response { Message="La actividad se eliminó correctamente" };
                }
                else 
                {
                    return new Response { Message="La actividad no se pudo eliminar correctamente" };
                }
               
            }   
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
                _activityRepository.Dispose();
            }
        }
    }
}