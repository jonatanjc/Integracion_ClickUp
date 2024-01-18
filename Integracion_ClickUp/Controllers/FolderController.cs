using ClickUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClickUp.Models;
using ClickUp.Moldels;

namespace clickup.api.controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class FolderController : ControllerBase
    {
        private readonly FolderService _service;

        public FolderController(FolderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("save-Folder")]
        public IActionResult SaveFolder([FromBody] FolderModel folderRequest)
        {
            return Ok("Datos guardados exitosamente");
        }

        [HttpGet]
        [Route ("integration")]
        public async Task<IActionResult> FolderIntegration()
        {

            var response = await _service.FolderIntegration();
            return Ok(response);
        }
     }
}

