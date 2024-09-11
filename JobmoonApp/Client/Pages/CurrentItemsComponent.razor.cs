namespace JobmoonApp.Client.Pages
{
    using Microsoft.AspNetCore.Components;
    using JobmoonApp.Shared.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using JobmoonApp.Client.Services;

    public partial class CurrentItemsComponent : ComponentBase
    {
        [Inject]
        public IItemService ItemService { get; set; }

        protected List<Item> Items { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Items = await ItemService.GetItemsAsync();

        }

        protected async Task MoveToArchive(Item item)
        {
            item.IsArchived = true;
            await ItemService.UpdateItemAsync(item);
            Items.Remove(item); // Remove from current list
        }
    }

}