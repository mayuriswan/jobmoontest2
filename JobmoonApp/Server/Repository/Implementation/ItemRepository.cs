using JobmoonApp.Server.Data;
using JobmoonApp.Server.Repository.Interface;
using JobmoonApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace JobmoonApp.Server.Repository.Implementation
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

       

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var existingItem = await _context.Items.FindAsync(item.Id);
            if (existingItem == null)
            {
                return false; // Item not found
            }

            existingItem.Name = item.Name;
            existingItem.IsArchived = item.IsArchived;

            await _context.SaveChangesAsync();
            return true;
        }

       
    }

}
