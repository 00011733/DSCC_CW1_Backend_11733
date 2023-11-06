using DSCC_CW1_Backend_11733.DbContexts;
using DSCC_CW1_Backend_11733.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSCC_CW1_Backend_11733.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public TopicController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/Topic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetTopics()
        {
            if (_context.Topics == null)
            {
                return NotFound();
            }
            return await _context.Topics.ToListAsync();
        }

        // GET: api/Topic/9
        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> GetTopic(int id)
        {
            if (_context.Topics == null)
            {
                return NotFound();
            }
            var topic = await _context.Topics.FindAsync(id);

            if (topic == null)
            {
                return NotFound();
            }

            return topic;
        }

        // PUT: api/Topic/4
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int id, Topic topic)
        {
            if (id != topic.Id)
            {
                return BadRequest();
            }

            _context.Entry(topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
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

        // POST: api/Topic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Topic>> PostTopic(Topic topic)
        {
            if (_context.Topics == null)
            {
                return Problem("Entity set 'TopicContext.Topics'  is null.");
            }
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopic", new { id = topic.Id }, topic);
        }

        // DELETE: api/Topic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            if (_context.Topics == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            // Retrieve all articles related to the topic
            var articles = await _context.Articles.Where(p => p.TopicId == id).ToListAsync();

            // Delete all articles related to the topic
            if (articles != null && articles.Count > 0)
            {
                _context.Articles.RemoveRange(articles);
            }

            // Now delete the article
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{id}/Articles")]
        public async Task<ActionResult<IEnumerable<Article>>> GetTopicArticles(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic == null)
            {
                return NotFound();
            }

            var topics = await _context.Articles.Where(p => p.TopicId == id).ToListAsync();

            return topics;
        }

        private bool TopicExists(int id)
        {
            return (_context.Topics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
