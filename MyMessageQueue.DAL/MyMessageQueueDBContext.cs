using Microsoft.EntityFrameworkCore;
using MyMessageQueue.Model;


namespace MyMessageQueue.DAL
{
    public class MyMessageQueueDBContext : DbContext
    {
        public DbSet<QueueMessage> MyMessageQueue { get; set; }
        public DbSet<LogMessage> ErrorLogs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=MyMessageQueue2B;Trusted_Connection=True;");
            }
        }
        public MyMessageQueueDBContext() { }
        public MyMessageQueueDBContext(DbContextOptions<MyMessageQueueDBContext> options) : base(options)
        {
            base.Database.Migrate();
        }

    }
}
