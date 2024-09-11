using JobmoonApp.Shared.Models;

namespace JobmoonApp.Server.Services.Interface
{
    public interface IItemService
    {
        Task<List<Item>> GetItemsAsync();
      
        Task<bool> UpdateItemAsync(int id, Item item);
    
    }
}
