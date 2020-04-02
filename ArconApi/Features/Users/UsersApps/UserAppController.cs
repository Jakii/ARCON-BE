using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Features.Users.UsersApps;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Users.UsersApps
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAppController : ControllerBase
    {
        private readonly UserAppServices _userAppService;
        public UserAppController(UserAppServices userAppService)
        {
            this._userAppService = userAppService;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> Get()
        {
            return await _userAppService.GetAll();
        } 

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] UserAppDto request)
        {
            return await _userAppService.Create(request);
        }
        
        [HttpPut]
        public async Task<ActionResult<Response>> Put(int id, [FromBody] UserAppDto request)
        {
            return await _userAppService.Update(id, request);
        }
    }
}