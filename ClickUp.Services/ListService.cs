using ClickUp.Models;
using ClickUp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClickUp.Services
{
    public class ListService
    {
        private readonly ListRepository repository;

        public ListService(ListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<ListModel>> ListIntegration()
        {
            try
            {
                var apiUrl = "https://api.clickup.com/api/v2/folder/90110975659/list";
                var apiToken = "pk_61752028_6C4BCUHMZKA8HLRJWSMEIH2Q1VYWWVGA";

                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                    request.Headers.Authorization = AuthenticationHeaderValue.Parse(apiToken);
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(responseString)) return new List<ListModel>();

                        IntegrationResponse integrationResponse = JsonSerializer.Deserialize<IntegrationResponse>(responseString);
                        if (integrationResponse == null) return new List<ListModel>();
                        if (integrationResponse.lists == null) return new List<ListModel>();

                        List<string> listIds = integrationResponse.lists.Select(x => x.id).ToList();
                        var recordsSaved = repository.GetAllByIds(listIds);
                        if (recordsSaved.Count == 0)
                        {
                            return repository.SaveMany(integrationResponse.lists);
                        }

                        foreach (var list in integrationResponse.lists)
                        {
                            var found = recordsSaved.FirstOrDefault(x => x.id == list.id);
                            if (found == null)
                            {
                                repository.SaveOne(list);
                            }
                            else
                            {
                                repository.Update(list);
                            }
                        }

                        return integrationResponse.lists;
                    }
                    else
                    {
                        Console.WriteLine($"Error al realizar la solicitud: {response.StatusCode}");
                        return new List<ListModel>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
                return new List<ListModel>();
            }
        }
    }
}








