using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFamily.Core;
using OdeToFamily.Data;

namespace OdeToFamily.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly OdeToFamilyDbContext _context;
        private readonly IPeopleData peopleData;

        public PeopleController(OdeToFamilyDbContext context,
                                IPeopleData peopleData)
        {
            _context = context;
            this.peopleData = peopleData;
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<People> GetPeople()
        {
            return _context.People;
        }

        // GET: api/People/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPeople([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var people = await _context.People.FindAsync(id);

            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeople([FromRoute] int id, [FromBody] People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != people.Id)
            {
                return BadRequest();
            }

            _context.Entry(people).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> PostPeople([FromBody] People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.People.Add(people);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeople", new { id = people.Id }, people);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeople([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var people = await _context.People.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            _context.People.Remove(people);
            await _context.SaveChangesAsync();

            return Ok(people);
        }

        private bool PeopleExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }

        // POST: api/People

        [HttpGet("{search}")]
        public IEnumerable<People> GetPeopleByName(string name)
        {
            var query = peopleData.GetByName(name);

            return query;
        }
    }
}