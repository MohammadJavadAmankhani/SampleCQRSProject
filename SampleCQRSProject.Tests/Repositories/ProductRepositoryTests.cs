using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using SampleCQRSProject.Infrastructure.Persistence;
using SampleCQRSProject.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class ProductRepositoryTests
{
    private readonly ApplicationDbContext _context;
    private readonly ProductRepository _repository;

    public ProductRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new ApplicationDbContext(options);
        _repository = new ProductRepository(_context);
    }

    [Fact]
    public async Task AddProduct_ShouldAddProductSuccessfully()
    {
        // Arrange
        var product = new Product { Name = "Test Product" };

        // Act
        await _repository.CreateAsync(product);
        await _context.SaveChangesAsync();
        var retrievedProduct = await _repository.GetByIdAsync(product.Id);

        // Assert
        Assert.NotNull(retrievedProduct);
        Assert.Equal("Test Product", retrievedProduct.Name);
    }

    [Fact]
    public async Task GetAllProducts_ShouldReturnProducts()
    {
        // Arrange
        _context.Database.EnsureDeleted();
        await _repository.CreateAsync(new Product { Name = "Product 1" });
        await _repository.CreateAsync(new Product { Name = "Product 2" });
        await _context.SaveChangesAsync();

        // Act
        var products = await _repository.GetAllAsync();

        // Assert
        Assert.NotEmpty(products);
        Assert.Equal(2, products.Count);
    }
}
