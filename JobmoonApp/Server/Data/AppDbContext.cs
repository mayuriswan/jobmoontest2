using JobmoonApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace JobmoonApp.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public void Seed()
        {
            if (!Items.Any())
            {
                Items.AddRange(
                    new Item { Name = "Item 1", IsArchived = false },
                    new Item { Name = "Item 2", IsArchived = false },
                    new Item { Name = "Item 3", IsArchived = true },
                    new Item { Name = "Item 4", IsArchived = false },
                    new Item { Name = "Item 5", IsArchived = true }
                );
                SaveChanges();
            }
        }
    }
}
