using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Features.Users.UserProfiles;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Statuses
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase 
    {
        private readonly StatusAppServices _statusAppService;
        public StatusController(StatusAppServices statusAppService)
        {
            this._statusAppService = statusAppService;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> Get()
        {
            return await _statusAppService.GetAll();
        } 

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] StatusDto request)
        {
            return await _statusAppService.Create(request);
        }
        
        [HttpPut]
        public async Task<ActionResult<Response>> Put(int id, [FromBody] StatusDto request)
        {
            return await _statusAppService.Update(id, request);
        }
    }
}