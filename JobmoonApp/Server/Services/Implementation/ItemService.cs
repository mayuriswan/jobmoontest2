using JobmoonApp.Server.Repository.Interface;
using JobmoonApp.Server.Services.Interface;
using JobmoonApp.Shared.Models;

namespace JobmoonApp.Server.Services.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await _itemRepository.GetItemsAsync();
        }

       

        public async Task<bool> UpdateItemAsync(int id, Item item)
        {
            var success = await _itemRepository.UpdateItemAsync(item);
            if (!success)
            {
                throw new Exception("Item not found");
            }
            return true;
        }

        
    }

}
