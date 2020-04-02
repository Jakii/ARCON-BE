using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Features.Users.UserProfiles;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Users.UserProfiles
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserProfileAppService _userProfileAppService;
        public UserProfileController(UserProfileAppService userProfileService)
        {
            this._userProfileAppService = userProfileService;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> Get()
        {
            return await _userProfileAppService.GetAll();
        } 

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] UserProfileDto request)
        {
            return await _userProfileAppService.Create(request);
        }
        
        [HttpPut]
        public async Task<ActionResult<Response>> Put(int id, [FromBody] UserProfileDto request)
        {
            return await _userProfileAppService.Update(id, request);
        }
    }
}