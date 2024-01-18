using ClickUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClickUp.Models;

namespace ClickUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly ListService _service;

        public ListController(ListService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("save-list")]
        public IActionResult SaveList([FromBody] ListModel listRequest)
        {
            return Ok("Datos guardados exitosamente");
        }

        [HttpGet]
        [Route("integration")]
        public async Task<IActionResult> ListIntegration()
        {
            try
            {
                var response = await _service.ListIntegration();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}