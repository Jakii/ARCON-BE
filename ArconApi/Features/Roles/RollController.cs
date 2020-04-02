using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Features.Roles;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Roles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollController : ControllerBase
    {
        private readonly RollAppServices _rollAppService;
        public RollController(RollAppServices rollService)
        {
            this._rollAppService = rollService;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> Get()
        {
            return await _rollAppService.GetAll();
        } 

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] RollDto request)
        {
            return await _rollAppService.Create(request);
        }
        
        [HttpPut]
        public async Task<ActionResult<Response>> Put(int id, [FromBody] RollDto request)
        {
            return await _rollAppService.Update(id, request);
        }
    }
}