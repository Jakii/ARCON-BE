
using System;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ArconApi.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Net.Http.Headers;

namespace ArconApi.Features.Goals.GoalDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalDetailController : ControllerBase
    {
        private readonly GoalDetailAppServices _goalDetailAppServices;
        public GoalDetailController(GoalDetailAppServices GoalAppServices)
        {
            _goalDetailAppServices=GoalAppServices;
        }
        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] GoalDetailDto request)
        {
            return await _goalDetailAppServices.Create(request);
        }
        
        [HttpPost]
        [Route("/api/GoalDetail/CreatedByListGoalDetail")]
        public async Task<ActionResult<Response>> CreatedByListGoalDetail([FromBody] GoalDetailDto request)
        {
            return await _goalDetailAppServices.Create(request);
        }
        [HttpGet]
        public async Task<ActionResult<Response>> Get()
        {
            return await _goalDetailAppServices.GetAll();
        } 

        [HttpGet]
        [Route("/api/GoalDetail/GetByGoalId")]
        public async Task<ActionResult<Response>> GetByGoalId(int goalId)
        {
            return await _goalDetailAppServices.GetAllByGoalId(goalId);
        } 

        [HttpGet]
        [Route("/api/GoalDetail/GetByGoalDetailId")]
        public async Task<ActionResult<Response>> GetByGoalDetailId(int goalDetailId)
        {
            return await _goalDetailAppServices.GetById(goalDetailId);
        } 
        [HttpPut]
        public async Task<ActionResult<Response>> Put(int id, [FromBody] GoalDetailDto request)
        {
            return await _goalDetailAppServices.Update(id, request);
        }

        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(int goalId )
        {
            return await _goalDetailAppServices.Delete(goalId);
        }
    }
}