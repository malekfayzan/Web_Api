using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Udemy_Demo_1.Models;

namespace Udemy_Demo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersDetailsController : ControllerBase
    {
     
        private readonly TaskDbmsContext _context;

        public UsersDetailsController(TaskDbmsContext context)
        {
            _context = context;
        }
     

        [HttpGet]
        // GET: api/UsersDetails
        public async Task<ActionResult<IEnumerable<UsersDetail>>> GetUsersDetails()
        {

            if (_context.UsersDetails == null)
          {
              return NotFound();
          }
            return await _context.UsersDetails.ToListAsync();
        }



        // GET: api/UsersDetails/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<UsersDetail>> GetUsersDetail(int id)
        {
          if (_context.UsersDetails == null)
          {
              return NotFound();
          }
            var usersDetail = await _context.UsersDetails.FindAsync(id);

            if (usersDetail == null)
            {
                return NotFound();
            }

            return usersDetail;
        }*/


              
         //    Sorting Element In Descending Ascending
         [HttpGet("{SortId}")]
                public IQueryable<UsersDetail> GetUserDetails(string SortId)
        {
            IQueryable<UsersDetail> usersDetails;
            switch (SortId)
            {
                case "des":
                    usersDetails = _context.UsersDetails.OrderByDescending(p => p.UserId);
                    break;
                case "asc":
                    usersDetails = _context.UsersDetails.OrderBy(p => p.UserId);
                    break;
                default:
                    usersDetails = _context.UsersDetails;
                    break;
            }
            return usersDetails;
        }

        //SP Execution For User Details
        /* [HttpGet("{Date}")]
           //[HttpGet("{id}")]
         public async Task<IEnumerable<UsersDetail>> UsersDetails([FromQuery] DateTime Date)
         {
             using (var context = new TaskDbmsContext())
             {
                 var data = await context.UsersDetails.FromSqlInterpolated($"Exec [dbo].[sp_User_Details]@Id = {Date}").ToListAsync();
                 return (IEnumerable<UsersDetail>)data;
             }
         }*/




        // PUT: api/UsersDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersDetail(int id, UsersDetail usersDetail)
        {
            if (id != usersDetail.UserId)
            {
                return BadRequest();
            }

            _context.Entry(usersDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersDetailExists(id))
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

        // POST: api/UsersDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsersDetail>> PostUsersDetail(UsersDetail usersDetail)
        {
          if (_context.UsersDetails == null)
          {
              return Problem("Entity set 'TaskDbmsContext.UsersDetails'  is null.");
          }
            _context.UsersDetails.Add(usersDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersDetail", new { id = usersDetail.UserId }, usersDetail);
        }

        // DELETE: api/UsersDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersDetail(int id)
        {
            if (_context.UsersDetails == null)
            {
                return NotFound();
            }
            var usersDetail = await _context.UsersDetails.FindAsync(id);
            if (usersDetail == null)
            {
                return NotFound();
            }

            _context.UsersDetails.Remove(usersDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersDetailExists(int id)
        {
            return (_context.UsersDetails?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
