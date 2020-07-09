using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Horsey.Data;
using Horsey.Domain;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HorseyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorseyController : ControllerBase
    {
        private static HorseyContext _context;
        public HorseyController(HorseyContext context)
        {
            _context = context;
        }

        // GET: api/<HorseyController>

        [HttpGet]
    public IActionResult Get()
    {
        List<Horse> horses = _context.Horses.ToList();
        return Ok(horses);
    }

    //[Route("api/TopStanding")]
    //[HttpGet(Name = "TopStanding")]
    //    public IActionResult TopStanding()
    //    {
    //        List<Horse> horses = _context.Horses.ToList();  //Where(h => h.Standing <= 4).
    //        return Ok(horses);
    //    }

    // GET api/<HorseyController>/5
    [HttpGet("{id}", Name="GetHorse")]
    [ActionName("GetHorse")]
    [Route("api/gethorse/{id}")]
    public IActionResult GetHorse(int id)
    {
        Horse horse = new Horse();
        horse = _context.Horses.Where(h => h.Id == id).FirstOrDefault();
        if (horse != null)
        {
            return Ok(horse);
        }
        else { 
            return NotFound(horse);
        }
    }


    // POST api/<HorseyController>
    [HttpPost]
        public IActionResult Post([FromBody] Horse horse)
        {
            //var test = value;
            //'Console.WriteLine(value);
            _context.Horses.Add(horse);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
            return CreatedAtRoute("GetHorse", new { id = horse.Id } , horse);
        }

    // PUT api/<HorseyController>/5
    [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Horse horse)
        {
            try
            {
                _context.Horses.Update(horse);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
            return CreatedAtRoute("GetHorse", new { id = horse.Id }, horse);
        }

    // DELETE api/<HorseyController>/5
    [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Horses.Remove(new Horse { Id = id });
            _context.SaveChanges();
        }
    }
}
