using System.Data.Entity;

namespace RSS_reader
{
    class ApplicationContext:DbContext
    {
        public ApplicationContext() : base("BasicConnection") { }
        public DbSet<Post> Posts { get; set; }
    }
}
