using SampleCQRSProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleCQRSProject.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<int> CreateAsync(Product product);
    }
}
