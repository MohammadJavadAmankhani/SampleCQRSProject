using System.Threading.Tasks;

namespace SampleCQRSProject.Domain.Interfaces
{
    public interface IEventStore
    {
        Task SaveEventAsync<T>(T eventData) where T : class;
    }
}
