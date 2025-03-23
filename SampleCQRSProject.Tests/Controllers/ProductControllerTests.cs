using Xunit;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleCQRSProject.API.Controllers;
using SampleCQRSProject.Domain.Entities;
using System.Collections.Generic;
using MediatR;
using SampleCQRSProject.Application.Queries;

public class ProductControllerTests
{
    [Fact]
    public async Task GetAll_ShouldReturnOkWithProducts()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), default))
            .ReturnsAsync(new List<Product>
            {
                new Product { Id = 1, Name = "Test Product 1" },
                new Product { Id = 2, Name = "Test Product 2" }
            });

        var controller = new ProductController(mockMediator.Object);

        // Act
        var result = await controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var products = Assert.IsType<List<Product>>(okResult.Value);
        Assert.Equal(2, products.Count);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator.Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), default))
            .ReturnsAsync((Product)null);

        var controller = new ProductController(mockMediator.Object);

        // Act
        var result = await controller.GetById(99);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
