using JobmoonApp.Shared.Models;

namespace JobmoonApp.Server.Repository.Interface
{
    public interface IItemRepository
    {
        Task<List<Item>> GetItemsAsync();
       
        Task<bool> UpdateItemAsync(Item item);
       
    }
}
