using Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Task_SoftServe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingRecordsController : ControllerBase
    {
        private SportLifeDbContext ctx;


        public TrainingRecordsController()
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(ctx.TrainingRecords.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.TrainingRecords.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(TrainingRecord model)
        {
            ctx.TrainingRecords.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(TrainingRecord model)
        {
            ctx.TrainingRecords.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.TrainingRecords.Find(id);
            if (item == null) return NotFound();
            ctx.TrainingRecords.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}
