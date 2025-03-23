using Microsoft.EntityFrameworkCore;
using SampleCQRSProject.Domain.Entities;

namespace SampleCQRSProject.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<EventStore> EventStores { get; set; }
    }

    public class EventStore
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public string EventData { get; set; }
    }
}
