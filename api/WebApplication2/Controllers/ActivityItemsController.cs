using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityItemsController : ControllerBase
    {
        private readonly ActivityContext _context;

        public ActivityItemsController(ActivityContext context)
        {
            _context = context;
        }

        // GET: api/ActivityItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityItem>>> GetActivityItems()
        {
            return await _context.ActivityItems.ToListAsync();
        }

        // GET: api/ActivityItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityItem>> GetActivityItem(long id)
        {
            var activityItem = await _context.ActivityItems.FindAsync(id);

            if (activityItem == null)
            {
                return NotFound();
            }

            return activityItem;
        }

        // PUT: api/ActivityItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityItem(long id, ActivityItem activityItem)
        {
            if (id != activityItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(activityItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityItemExists(id))
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

        // POST: api/ActivityItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivityItem>> PostActivityItem(ActivityItem activityItem)
        {
            _context.ActivityItems.Add(activityItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivityItem), new { id = activityItem.Id }, activityItem);
        }

        // DELETE: api/ActivityItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityItem(long id)
        {
            var activityItem = await _context.ActivityItems.FindAsync(id);
            if (activityItem == null)
            {
                return NotFound();
            }

            _context.ActivityItems.Remove(activityItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ActivityItems
        [HttpDelete]
        public async Task<IActionResult> DeleteActivityItems() {
            foreach (var entity in _context.ActivityItems) {
                _context.ActivityItems.Remove(entity);
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityItemExists(long id)
        {
            return _context.ActivityItems.Any(e => e.Id == id);
        }
    }
}
