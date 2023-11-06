namespace DSCC_CW1_Backend_11733.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int TopicId { get; set; }
        public Topic ArticleTopic { get; set; }
    }
}
