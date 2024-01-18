using ClickUp.Models;
using ClickUp.Moldels;
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
    public class FolderService
    {
        private readonly FolderRepository repository;

        public FolderService(FolderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<FolderModel>> FolderIntegration()
        {
            try
            {
                var apiUrl = "https://api.clickup.com/api/v2/space/90110430068/folder";
                var apiToken = "pk_61752028_6C4BCUHMZKA8HLRJWSMEIH2Q1VYWWVGA";

                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                    request.Headers.Authorization = AuthenticationHeaderValue.Parse(apiToken);
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(responseString)) return new List<FolderModel>();

                        IntegrationResponse integrationResponse = JsonSerializer.Deserialize<IntegrationResponse>(responseString);
                        if (integrationResponse == null) return new List<FolderModel>();
                        if (integrationResponse.folders == null) return new List<FolderModel>();

                        List<string> listIds = integrationResponse.folders.Select(x => x.id).ToList();
                        var recordsSaved = repository.GetAllByIds(listIds);

                        foreach (var folder in integrationResponse.folders)
                        {
                            var finded = recordsSaved.FirstOrDefault(x => x.id == folder.id);
                            if (finded == null)
                            {
    
                                Console.WriteLine($"Carpeta actualizada: {folder.id}");
                            }
                            else
                            {

                                Console.WriteLine($"Ninguna actualizacion: {folder.id}");
                            }
                        }

                        return integrationResponse.folders;
                    }
                    else
                    {
                        Console.WriteLine($"Error al realizar la solicitud: {response.StatusCode}");
                        return new List<FolderModel>();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
                return new List<FolderModel>();
            }
        }
    }
}

































//using ClickUp.Models;
//using ClickUp.Repositories;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;
//using System.Text.Json;
//using ClickUp.Moldels;

//namespace ClickUp.Services
//{
//    public class FolderService
//    {

//        private readonly FolderRepository repository;
//        public FolderService(FolderRepository repository)
//        {
//            this.repository = repository;
//        }

//        public async Task<List<FolderModel>> FolderIntegration()
//        {
//            try
//            {
//                var apiUrl = "https://api.clickup.com/api/v2/space/90110430068/folder";
//                var apiToken = "pk_61752028_6C4BCUHMZKA8HLRJWSMEIH2Q1VYWWVGA";

//                using (var client = new HttpClient())
//                {

//                    var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
//                    request.Headers.Authorization = AuthenticationHeaderValue.Parse(apiToken);
//                    var response = await client.SendAsync(request);


//                    if (response.IsSuccessStatusCode)
//                    {
//                        var responseString = await response.Content.ReadAsStringAsync();
//                        if (string.IsNullOrEmpty(responseString)) return new();
//                        IntegrationResponse integrationResponse = JsonSerializer.Deserialize<IntegrationResponse>(responseString);
//                        if (integrationResponse == null) return new();
//                        if (integrationResponse.folders == null) return new();
//                        return repository.SaveList(integrationResponse.folders);
//                    }

//                    else
//                    {
//                        return new();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error general: {ex.Message}");
//            }
//            return new();
//        }
//    }
//}

