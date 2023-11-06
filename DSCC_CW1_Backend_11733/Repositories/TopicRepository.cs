using DSCC_CW1_Backend_11733.DbContexts;
using DSCC_CW1_Backend_11733.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC_CW1_Backend_11733.Repositories
{
    public class TopicRepository
    {
        private readonly BlogDbContext _context; // Use the appropriate DbContext here

        public TopicRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Topic>> GetAllTopicsAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<Topic> GetTopicByIdAsync(int id)
        {
            return await _context.Topics.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Topic> CreateTopicAsync(Topic topic)
        {
            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            return topic;
        }

        public async Task<Topic> UpdateTopicAsync(int id, Topic topic)
        {
            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            var existingTopic = await _context.Topics.FirstOrDefaultAsync(t => t.Id == id);
            if (existingTopic == null)
            {
                return null; // Topic with the specified ID not found
            }

            existingTopic.Name = topic.Name;
            await _context.SaveChangesAsync();

            return existingTopic;
        }

        public async Task<bool> DeleteTopicAsync(int id)
        {
            var topic = await _context.Topics.FirstOrDefaultAsync(t => t.Id == id);
            if (topic == null)
            {
                return false; // Topic with the specified ID not found
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return true; // Topic deleted successfully
        }

        //public void DeleteTopic(int topicId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Topic GetTopicById(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Topic> GetTopics()
        //{
        //    throw new NotImplementedException();
        //}

        //public void InsertTopic(Topic topic)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateTopic(Topic topic)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
