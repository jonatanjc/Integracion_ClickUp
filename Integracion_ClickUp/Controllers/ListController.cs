using ClickUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        public readonly ListService _service;

        public ListController(ListService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get-by-user")]
        public IActionResult GetListsByUser(short user)
        {
            return Ok();
        }
    }
}
