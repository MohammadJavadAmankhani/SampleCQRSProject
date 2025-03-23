using System.Text.Json;
using SampleCQRSProject.Domain.Interfaces;

namespace SampleCQRSProject.Infrastructure.Persistence
{
    public class EventStoreService : IEventStore
    {
        private readonly ApplicationDbContext _context;

        public EventStoreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveEventAsync<T>(T eventData) where T : class
        {
            var eventStore = new EventStore
            {
                EventType = typeof(T).Name,
                EventData = JsonSerializer.Serialize(eventData)
            };

            _context.EventStores.Add(eventStore);
            await _context.SaveChangesAsync();
        }
    }
}
