using DSCC_CW1_Backend_11733.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC_CW1_Backend_11733.DbContexts
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
