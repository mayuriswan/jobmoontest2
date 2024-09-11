using JobmoonApp.Shared.Models;

namespace JobmoonApp.Client.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetItemsAsync();
        Task UpdateItemAsync(Item item);
    }
}
