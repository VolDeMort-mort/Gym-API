using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using Data;

namespace Core_Task_SoftServe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private SportLifeDbContext ctx;


        public ScheduleController()
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(ctx.Schedules.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.Schedules.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Schedule model)
        {
            ctx.Schedules.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Schedule model)
        {
            ctx.Schedules.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Schedules.Find(id);
            if (item == null) return NotFound();
            ctx.Schedules.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}
