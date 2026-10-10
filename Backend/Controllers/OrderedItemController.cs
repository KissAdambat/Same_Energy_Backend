using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("Order")]
    [ApiController]
    public class OrderedItemController : ControllerBase
    {
        public SameEnergyDBContext Context = new SameEnergyDBContext();
        [HttpGet("GetAllOrderedItems")]
        public object GetAllOrders()
        {
            var ordered_item = Context.Order_Items.ToList();
            return new { message = "Sikeres lekérdezés", data = ordered_item };
        }

        [HttpGet("GetAnOrdered_Item/{id}")]
        public object GetAnOrdered_Item([FromRoute] int id)
        {
            var existingOrdered_Item = Context.Order_Items.FirstOrDefault(o => o.id == id);
            if (existingOrdered_Item != null)
            {
                return existingOrdered_Item;
            }
            else
            {
                return NotFound(new { message = "Nem található megrendelés" });
            }
        }

        [HttpPost("AddOrdered_Item")]
        public object AddOrdered_Item(AddNewOrdereItemDTO dto)
        {
            var ordered_item = new OrderedItemM
            {
                order_id = dto.order_id,
                product_id = dto.product_id,
                product_name = dto.product_name,
                size = dto.size,
                quantity = dto.quantity,
                unit_price = dto.unit_price

            };
            Context.Order_Items.Add(ordered_item);
            Context.SaveChanges();
            return StatusCode(201, new { message = "Sikeres hozzáadás:", result = ordered_item });
        }

        [HttpDelete("DeleteOrderedItem/{id}")]
        public object DeleteOrder([FromRoute] int id)
        {
            var existingOrderedItem = Context.Order_Items.FirstOrDefault(o => o.id == id);
            if (existingOrderedItem == null)
            {
                return NotFound(new { message = "Nem található item" });
            }
            Context.Order_Items.Remove(existingOrderedItem);
            Context.SaveChanges();
            return StatusCode(200, new { message = "Sikeres törlés:", result = existingOrderedItem });
        }

    }
}
