using System.Threading.Tasks;
using ArconApi.Common;
using ArconApi.Feature.Category;
using Microsoft.AspNetCore.Mvc;

namespace ArconApi.Features.Categories{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       private readonly CategoryAppServices _categoryAppService;

        public CategoryController(CategoryAppServices categoryAppService)
        {
            this._categoryAppService = categoryAppService;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> Get()
        {
            return await _categoryAppService.GetAll();
        } 
        
        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] CategoryDto request)
        {
            return await _categoryAppService.Create(request);
        }
        
        [HttpPut]
        public async Task<ActionResult<Response>> Put(int id, [FromBody] CategoryDto request)
        {
            return await _categoryAppService.Update(id, request);
        }

        
        [HttpPut]
         [Route("/api/Category/Disable")]
        public async Task<ActionResult<Response>> Disable(int id)
        {
            return await _categoryAppService.Disable(id);
        }
    }
}