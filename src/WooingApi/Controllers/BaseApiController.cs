using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WooingApi.Controllers
{
    [ApiController]    
    [Authorize]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}