using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Data;
using ArconApi.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Goals.GoalDetails
{
    public class GoalDetailAppServices : IDisposable
    {
        private readonly IGenericRepository<GoalDetail> _goalDetailRepository;
        private readonly IMapper _mapper;
        public GoalDetailAppServices(IGenericRepository<GoalDetail> goalDetailRepository,
        IMapper mapper)
        {
            _goalDetailRepository=goalDetailRepository;
            _mapper=mapper;
        }
        public async Task<ActionResult<Response>> Create(GoalDetailDto request)
        {
            GoalDetail goalDetail= new GoalDetail.Builder(request.GoalId,request.ActivityId, request.IsComplete, request.TransactionDate)
                                                 .Build();
           
            await _goalDetailRepository.AddAsyn(goalDetail);
            await _goalDetailRepository.SaveAsync();
            return new Response { Data = _mapper.Map<GoalDetailDto>(goalDetail) };
        }
        public async Task<ActionResult<Response>> CreateByList(List<GoalDetailDto> goalDetails)
        {
            List<GoalDetail> goalDetailList= new List<GoalDetail>();
            foreach(var request in goalDetails )
            {
                GoalDetail goalDetail= new GoalDetail.Builder(request.GoalId,request.ActivityId, request.IsComplete, request.TransactionDate)
                                                    .Build();
            
                await _goalDetailRepository.AddAsyn(goalDetail);
                var value= await _goalDetailRepository.SaveAsync();
                if(value>0) 
                {
                    goalDetailList.Add(goalDetail);
                }
            }
             return new Response { Data =  _mapper.Map<IEnumerable<GoalDetailDto>>(goalDetailList) };
        }
         public async Task<Response> GetAll()
        {
            IEnumerable<GoalDetail> goalDetails = await _goalDetailRepository.GetAllAsyn();
           
            if(goalDetails!=null && goalDetails.Any())
            {
                return new Response { Data =  _mapper.Map<IEnumerable<GoalDetailDto>>(goalDetails) };
            }else 
            {
                return new Response{ Message="La lista de goal detalis esta vacia"};
            }

        }
        public async Task<Response> GetById(int goalDetailId)
        {
            GoalDetail goalDetail = await _goalDetailRepository.GetAsync(goalDetailId);
           
            if(goalDetail!=null )
            {
                return new Response { Data =  _mapper.Map<GoalDetailDto>(goalDetail) };
            }else 
            {
                return new Response{ Message=$"No se encontro el goal detail con id:{goalDetailId}"};
            }
        }
        public async Task<Response> GetAllByGoalId(int goalId)
        {
            IEnumerable<GoalDetail> goalDetails = await _goalDetailRepository.FindAllAsync(x=>x.GoalId==goalId);
            
            if(goalDetails!=null && goalDetails.Any())
            {
                return new Response { Data =  _mapper.Map<IEnumerable<GoalDetailDto>>(goalDetails) };
            }else 
            {
                return new Response{ Message=$"No se encontro goal details para el goal id:{goalId}"};
            }
        }
        public async Task<Response> Update(int id, GoalDetailDto request)
        {
            GoalDetail goalDetail = await _goalDetailRepository.GetAsync(id);
            
            if (goalDetail == null)
            {
                return new Response {Message=$"No se encontro goaldetail con el id:{id} "};
            }
            goalDetail.SetIsComplete(request.IsComplete);
            goalDetail.SetTransactionDate(request.TransactionDate);
            await _goalDetailRepository.SaveAsync();
            return new Response { Data = _mapper.Map<GoalDetailDto>(goalDetail) };
        }
        public async Task<Response> Delete(int goalDetailId)
        {
            GoalDetail goalDetailFind = await _goalDetailRepository.GetAsync(goalDetailId);
            if (goalDetailFind == null)
            {
                return new Response {Message=$"No se encontro goal detail para el id:{goalDetailId} "};
            }
            else
            {
                var value=await _goalDetailRepository.DeleteAsyn(goalDetailFind);
                if(value>0)
                {
                    await _goalDetailRepository.SaveAsync();
                    return new Response { Message="El goal detail se eliminó correctamente" };
                }
                else 
                {
                    return new Response { Message="El goal detail no se pudo eliminar correctamente" };
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
                _goalDetailRepository.Dispose();
            }
        }
    }
}