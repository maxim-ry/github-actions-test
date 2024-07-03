using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IScopedService _scopedService;
        public TestController(IScopedService scopedService)
        {
            _scopedService = scopedService;
        }
        [HttpGet]
        public ActionResult<Guid> Get()
        {
            return _scopedService.GetOperationID();
        }
    }
}
