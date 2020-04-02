using System.Threading.Tasks;
using ArconApi.Common;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Feature.Activities
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivityAppServices _activityAppServices;
        public ActivityController(ActivityAppServices activityAppServices)
        {
            _activityAppServices=activityAppServices;
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] GoalActivityDto request)
        {
            return await _activityAppServices.Create(request);
        }
        [HttpGet]
        public async Task<ActionResult<Response>> Get()
        {
            return await _activityAppServices.GetAll();
        } 
        [HttpGet]
        [Route("/api/Activity/GetById")]
        public async Task<ActionResult<Response>> GetById(int activityId)
        {
            return await _activityAppServices.GetActivityById(activityId);
        } 
        [HttpPut]
        public async Task<ActionResult<Response>> Put(int id, [FromBody] GoalActivityDto request)
        {
            return await _activityAppServices.Update(id, request);
        }
        
        [HttpDelete]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            return await _activityAppServices.Delete(id);
        }
    }
}