using DSCC_CW1_Backend_11733.Models;

namespace DSCC_CW1_Backend_11733.Repositories
{
    public interface ITopicRepository
    {
        void CreateTopicAsync(Topic topic);
        void UpdateTopicAsync(Topic topic);
        void DeleteTopicAsync(int topicId);
        Topic GetTopicByIdAsync(int Id);
        IEnumerable<Topic> GetAllTopicsAsync();
    }
}
