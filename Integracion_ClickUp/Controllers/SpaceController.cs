using ClickUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClickUp.Models;

namespace ClickUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class SpaceController : ControllerBase
    {
        private readonly SpacesService _service;

        public SpaceController(SpacesService service)
        {
            _service = service;
        }

        

        [HttpPost]
        [Route("save-space")]
        public IActionResult SaveSpace([FromBody] SpaceModel spaceRequest)
        {
            return Ok("Datos guardados exitosamente");
        }

        [HttpGet]
        [Route("integration")]
        public async Task<IActionResult> SpaceIntegration()
        {
            var response = await _service.SpaceIntegration();
            return Ok(response);
        }
    }
}

