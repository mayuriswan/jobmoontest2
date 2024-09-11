using JobmoonApp.Shared;
using JobmoonApp.Shared.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace JobmoonApp.Client.Services.Implementation
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "/api/items";

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Item>> GetItemsAsync()
        {

            try
            {
                return await _httpClient.GetFromJsonAsync<List<Item>>(BaseUrl);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return new List<Item>();  // Return empty list or handle the error accordingly
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error: {ex.Message}");
                return new List<Item>();
            }
        }

      
        public async Task UpdateItemAsync(Item item)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{item.Id}", item);
            response.EnsureSuccessStatusCode();
        }
    }
}
