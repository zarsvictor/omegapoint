using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Omegapoint_uppgift.Models;

namespace Omegapoint_uppgift.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class PersonController : ControllerBase
    {

        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return _context.Persons.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _context.Persons.Find(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            _context.Persons.Add(person);

            int n = _context.SaveChanges();

            if (n == 0)
            {
                return Problem("Something went wrong when creating the person");
            }

            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, Person person)
        {
            var userEntity = _context.Persons.Find(id);

            userEntity.FirstName = person.FirstName;
            userEntity.LastName = person.LastName;
            userEntity.age = person.age;

            _context.Entry(userEntity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(int id)
        {
            var user = _context.Persons.Find(id);
            if (user == null)
                return NotFound();

            _context.Persons.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
