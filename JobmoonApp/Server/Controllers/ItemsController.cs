using JobmoonApp.Server.Services.Interface;
using JobmoonApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobmoonApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemService.GetItemsAsync();
            return Ok(items);
        }

       

        

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] Item item )
        {
            var success = await _itemService.UpdateItemAsync(id, item);
            if (!success)
            {
                return NotFound(new { message = "Item not found" });
            }

            return NoContent();
        }

    }

}
