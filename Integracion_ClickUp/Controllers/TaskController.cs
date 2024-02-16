using ClickUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClickUp.Models;

namespace clickup.api.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _service;

        public TaskController(TaskService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("save-task")]
        public IActionResult SaveTask([FromBody] TaskModel taskRequest)
        {
            return Ok("Datos guardados exitosamente");
        }

        [HttpGet]
        [Route("integration")]
        public async Task<IActionResult> TaskIntegration(string list)
        {

            var response = await _service.TaskIntegration(list);
            return Ok(response);
        }
    }
}

