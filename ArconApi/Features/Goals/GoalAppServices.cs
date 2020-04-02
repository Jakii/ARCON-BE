using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Data;
using ArconApi.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Goals
{
    public class GoalAppServices : IDisposable
    {
        private readonly IGenericRepository<Goal> _goalRepository;
        private readonly IMapper _mapper;
        public GoalAppServices(IGenericRepository<Goal> goalRepository,IMapper mapper)
        {
            _goalRepository=goalRepository;
            _mapper=mapper;
        }
        
        public async Task<ActionResult<Response>> Create(GoalDto request)
        {
            Goal Goal= new Goal.Builder(request.ProfileId, request.Title, request.Amount, request.Progress)
                                .WithDescription(request.Description)
                                .WithStatusId(request.StatusId)
                                .WithTransactionDate(request.TransactionDate)
                                .WithUpdateDate(request.UpdateDate)
                                .WithTransferDate(request.TransferDate)
                                .Build();
           
            await _goalRepository.AddAsyn(Goal);
            await _goalRepository.SaveAsync();
            return new Response { Data = _mapper.Map<Goal>(Goal) };
        }

        public async Task<Response> GetAll()
        {
            IEnumerable<Goal> goals = await _goalRepository.GetAllAsyn();
           
            if(goals!=null && goals.Any())
            {
                return new Response { Data =  _mapper.Map<IEnumerable<GoalDto>>(goals) };
            }else 
            {
                return new Response{ Message="La lista de goals esta vacia"};
            }

        }
        public async Task<Response> GetAllByUserProfileId(int userProfileId)
        {
            IEnumerable<Goal> goals = await _goalRepository.FindAllAsync(x=>x.ProfileId==userProfileId);
            
            if(goals!=null && goals.Any())
            {
                return new Response { Data =  _mapper.Map<IEnumerable<GoalDto>>(goals) };
            }else 
            {
                return new Response{ Message=$"No se encontro goals para el user id:{userProfileId}"};
            }
        }


        public async Task<Response> Update(int id, GoalDto request)
        {
            Goal goal = await _goalRepository.GetAsync(id);
            
            if (goal == null)
            {
                return new Response {Message=$"No se encontro goals con el id:{id} "};
            }

            goal.SetAmount(request.Amount);
            goal.SetDescription(request.Description);
            goal.SetProgress(request.Progress);
            goal.SetStatusId(request.StatusId);
            goal.SetTitle(request.Title);
            goal.SetTransactionDate(request.TransactionDate);
           
            await _goalRepository.SaveAsync();
            return new Response { Data = _mapper.Map<Goal>(goal) };
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
                
                _goalRepository.Dispose();
            }
        }
    }
}