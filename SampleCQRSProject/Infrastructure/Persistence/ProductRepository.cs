using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleCQRSProject.Domain.Entities;
using SampleCQRSProject.Domain.Interfaces;

namespace SampleCQRSProject.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(int id) => await _context.Products.FindAsync(id);

        public async Task<List<Product>> GetAllAsync() => await _context.Products.ToListAsync();

        public async Task<int> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
