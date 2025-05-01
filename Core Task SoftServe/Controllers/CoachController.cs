using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using Data;

namespace Core_Task_SoftServe.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]

    public class CoachController : ControllerBase
    {
        private SportLifeDbContext ctx;


        public CoachController()
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(ctx.Coaches.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.Coaches.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Coach model)
        {
            ctx.Coaches.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Coach model)
        {
            ctx.Coaches.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Coaches.Find(id);
            if (item == null) return NotFound();
            ctx.Coaches.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}
