using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using Data;

namespace Core_Task_SoftServe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private SportLifeDbContext ctx;


        public PaymentController() 
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll() 
        {
            return Ok(ctx.Payments.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.Payments.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Payment model)
        {
            ctx.Payments.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Payment model)
        {
            ctx.Payments.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Payments.Find(id);
            if (item == null) return NotFound();
            ctx.Payments.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}
