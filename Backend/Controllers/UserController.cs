using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public SameEnergyDBContext Context = new SameEnergyDBContext();
        [HttpGet("GetAllUsers")]
        public object GetAllUsers()
        {
            var users = Context.Users.ToList();
            return new { message = "Sikeres lekérdezés", data = users };
        }

        [HttpGet("GetAUser/{id}")]
        public object GetAUser([FromRoute] int id)
        {
            var existingUser = Context.Users.FirstOrDefault(u => u.id == id);
            if (existingUser != null)
            {
                return existingUser;
            }
            else
            {
                return NotFound(new { message = "Nem található a felhasználó" });
            }
        }

        [HttpPost("AddUser")]
        public object AddUser(AddNewUserDTO dto)
        {
            var user = new UserM
            {
                name = dto.name,
                email = dto.email,
                password = dto.password,
                role = "Customer"
            };
            Context.Users.Add(user);
            Context.SaveChanges();
            return StatusCode(201, new { message = "Sikeres hozzáadás:", result = user });
        }

        [HttpPut("UpdateUser/{id}")]
        public object UpdateUser([FromRoute] int id, [FromBody] UpdateUserDTO updateuserDto)
        {
            var user = Context.Users.FirstOrDefault(u => u.id == id);

            if (user != null)
            {
                user.name = updateuserDto.name;
                user.email = updateuserDto.email;
                user.password = updateuserDto.password;
                user.phone = updateuserDto.phone;
                user.address = updateuserDto.address;

                Context.Users.Update(user);
                Context.SaveChanges();

                return StatusCode(200, new { message = "Sikeres frissítés", result = user });
            }

            return StatusCode(404, new { message = "Sikertlen frissítés", result = user });
        }

        [HttpDelete("DeleteUser/{id}")]
        public object DeleteUser([FromRoute] int id)
        {
            var existingUser = Context.Users.FirstOrDefault(u => u.id == id);
            if (existingUser == null)
            {
                return NotFound(new { message = "Nem található a megadott felhasználó." });
            }
            Context.Users.Remove(existingUser);
            Context.SaveChanges();
            return StatusCode(200, new { message = "Sikeres törlés:", result = existingUser });
        }
    }
}
