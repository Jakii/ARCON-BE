using System.Threading.Tasks;
using ArconApi.Common;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Goals
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly GoalAppServices _goalAppServices;
        public GoalController(GoalAppServices GoalAppServices)
        {
            _goalAppServices=GoalAppServices;
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] GoalDto request)
        {
            return await _goalAppServices.Create(request);
        }
        [HttpGet]
        public async Task<ActionResult<Response>> Get()
        {
            return await _goalAppServices.GetAll();
        } 

        [HttpGet]
        [Route("/api/Goals/GetByUserProfileId")]
        public async Task<ActionResult<Response>> GetByUserProfileId(int userProfileId)
        {
            return await _goalAppServices.GetAllByUserProfileId(userProfileId);
        } 

        [HttpGet]
        [Route("/api/Goals/GetByGoalId")]
        public async Task<ActionResult<Response>> GetByGoalId(int goalId)
        {
            return await _goalAppServices.GetById(goalId);
        } 
        [HttpPut]
        public async Task<ActionResult<Response>> Put(int id, [FromBody] GoalDto request)
        {
            return await _goalAppServices.Update(id, request);
        }
    }
}