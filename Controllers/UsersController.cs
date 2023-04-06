using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")] // Controller for Request to localhost:7017/api/Users
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public UsersController(UniversityDBContext context)
        {
            _context = context;
        }

        // Obtener todos los elementos --> GET: https://localhost:7017/api/Users/GetUsers
        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync() != null ? await _context.Users.ToListAsync() : NotFound();
        }

        // Obtener un elemento --> GET: https://localhost:7017/api/Users/GetUser/1
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<User>> GetUser(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NoContent();
            }

            return user;
        }

        //Insertar elemento --> POST:  https://localhost:7017/api/Users/PostUser
        [HttpPost("PostUser")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // Actualizar Elemento --> PUT:  https://localhost:7017/api/Users/PutUser/1
        [HttpPut("PutUser/{id}")]
        public async Task<ActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;  

            try
            {
                await _context.SaveChangesAsync();
           }
            catch (DbUpdateConcurrencyException)
            {
                if(!UserExists(id))
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



        // Delete: Eliminar elemento --> Delete: https://localhost:7017/api/Users/DeleteUser/1
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            User user = await _context.Users.FindAsync(id);
            
            if(user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #region OtrosMetodos
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        #endregion OtrosMetodos

    }
}
