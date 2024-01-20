using ClickUp.Models;
using ClickUp.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ClickUp.Moldels;

namespace ClickUp.Services
{
    public class TaskService
    {
        private readonly TaskRepository repository;
        public TaskService(TaskRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<TaskModel>> TaskIntegration()
        {
            try
            {
                var apiUrl = "https://api.clickup.com/api/v2/list/901101974608/task";
                var apiToken = "pk_61752028_6C4BCUHMZKA8HLRJWSMEIH2Q1VYWWVGA";

                using (var client = new HttpClient())
                {

                    var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                    request.Headers.Authorization = AuthenticationHeaderValue.Parse(apiToken);
                    var response = await client.SendAsync(request);


                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(responseString)) return new();
                        TaskModel tarea = JsonSerializer.Deserialize<TaskModel>(responseString);
                        //if (integrationResponse == null) return new();
                        //if (integrationResponse.task == null) return new();
                        if (tarea == null) return new();
                        return repository.InsertOne(tarea);
                    }
                    else
                    {
                        return new();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
            }
            return new();
        }
    }
}
