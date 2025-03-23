using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using SampleCQRSProject.Application.Commands;
using SampleCQRSProject.Application.Handlers;
using SampleCQRSProject.Domain.Entities;
using SampleCQRSProject.Domain.Events;
using SampleCQRSProject.Domain.Interfaces;
using System.Timers;

public class CreateProductHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateProductAndSaveEvent()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        var mockEventStore = new Mock<IEventStore>();

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<Product>())).ReturnsAsync(1);
        mockEventStore.Setup(e => e.SaveEventAsync(It.IsAny<ProductCreatedEvent>())).Returns(Task.CompletedTask);

        var handler = new CreateProductHandler(mockRepo.Object, mockEventStore.Object);
        var command = new CreateProductCommand { Name = "New Product", Price = 99.99m };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal(1, result);
        mockRepo.Verify(r => r.CreateAsync(It.IsAny<Product>()), Times.Once);
        mockEventStore.Verify(e => e.SaveEventAsync(It.IsAny<ProductCreatedEvent>()), Times.Once);
    }
}
