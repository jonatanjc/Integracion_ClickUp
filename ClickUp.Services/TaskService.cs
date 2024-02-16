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

        public async Task<List<TaskModel>> TaskIntegration(string listId)
        {
            StatusModel status = new StatusModel();
            status.color = "blue";
            status.Test();
            status.SetColor("red");
            var statusId = status.GetId();
            try
            {
                var apiUrl = $"https://api.clickup.com/api/v2/list/{listId}/task";
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
                        ResponseTask taskresponse = JsonSerializer.Deserialize<ResponseTask>(responseString);
                        if (taskresponse == null) return new();
                        if (taskresponse.tasks == null) return new();
                        if (taskresponse.tasks.Count() == 0) return new();
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
