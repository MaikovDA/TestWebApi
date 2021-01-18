using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		readonly UsersContext _db;

        public UsersController(UsersContext context)
        {
            _db = context;
            if (_db.Users.Any()) return;

            _db.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _db.Users.ToListAsync();
        }

        // GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
	            return BadRequest();

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!_db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            _db.Update(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(Guid id)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
