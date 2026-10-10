using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public SameEnergyDBContext Context = new SameEnergyDBContext();
        [HttpGet("GetAllOrder")]
        public object GetAllOrders()
        {
            var orders = Context.Orders.ToList();
            return new { message = "Sikeres lekérdezés", data = orders };
        }

        [HttpGet("GetAnOrder/{id}")]
        public object GetAnOrder([FromRoute] int id)
        {
            var existingOrder = Context.Orders.FirstOrDefault(o => o.id == id);
            if (existingOrder != null)
            {
                return existingOrder;
            }
            else
            {
                return NotFound(new { message = "Nem található megrendelés" });
            }
        }

        [HttpPost("AddOrder")]
        public object AddOrder(AddNewOrderDTO dto)
        {
            var order = new OrderM
            {
                user_id = dto.user_id,
                total_price = dto.total_price,
                order_date = DateTime.Now,
                status = "Paid"
            };
            Context.Orders.Add(order);
            Context.SaveChanges();
            return StatusCode(201, new { message = "Sikeres hozzáadás:", result = order });
        }

        [HttpDelete("DeleteOrder/{id}")]
        public object DeleteOrder([FromRoute] int id)
        {
            var existingOrder = Context.Orders.FirstOrDefault(o => o.id == id);
            if (existingOrder == null || existingOrder.status == "shipped")
            {
                return NotFound(new { message = "Nem található vagy már el lett küldve a megrendelés." });
            }
            Context.Orders.Remove(existingOrder);
            Context.SaveChanges();
            return StatusCode(200, new { message = "Sikeres törlés:", result = existingOrder });
        }
    }
}
