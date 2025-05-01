using Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Task_SoftServe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController: ControllerBase
    {
        private SportLifeDbContext ctx;


        public TrainingController()
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(ctx.Trainings.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.Trainings.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Training model)
        {
            ctx.Trainings.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Training model)
        {
            ctx.Trainings.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Trainings.Find(id);
            if (item == null) return NotFound();
            ctx.Trainings.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}
