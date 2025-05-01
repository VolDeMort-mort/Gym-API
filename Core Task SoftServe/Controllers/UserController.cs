using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using Data;

namespace Core_Task_SoftServe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private SportLifeDbContext ctx;


        public UserController() 
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll() 
        {
            return Ok(ctx.Users.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.Users.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            ctx.Users.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(User model)
        {
            ctx.Users.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Users.Find(id);
            if (item == null) return NotFound();
            ctx.Users.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}
