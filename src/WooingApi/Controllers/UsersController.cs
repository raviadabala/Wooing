using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WooingApi.Controllers
{
    public class UsersController : BaseApiController
    {
        public UsersController(IConfiguration configuration)
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;
            return Ok("Hello");
        }  
    }
}