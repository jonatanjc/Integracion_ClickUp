using ClickUp.Models;
using ClickUp.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Core.WireProtocol.Messages;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ClickUp.Services
{
    public class SpacesService
    {

        private readonly SpaceRepository repository; 
        public SpacesService(SpaceRepository repository)  
        {
            this.repository = repository; 
        }

        public async Task<List<SpaceModel>> SpaceIntegration()
        {
            try
            {
                var apiUrl = "https://api.clickup.com/api/v2/team/9011053573/space";
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
                        FolderResponse responseSpace = JsonSerializer.Deserialize<FolderResponse>(responseString);
                        if (responseSpace == null) return new();
                        return repository.SaveList(responseSpace.spaces);
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
        public SpaceModel FindById(string id)  
        {
            return repository.GetById(id);
        }
    }
}
