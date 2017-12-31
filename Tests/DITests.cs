using DependencyInjection.Controllers;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            // Arrange
            decimal total = 100;
            var data = new[] { new Product { Name = "Test", Price = total } };
            var mockIRepository = new Mock<IRepository>();
            mockIRepository.SetupGet(m => m.Products).Returns(data);

            ProductTotalizer totalizer = new ProductTotalizer(mockIRepository.Object);

            HomeController controller = new HomeController(mockIRepository.Object);

            // Act
            ViewResult result = controller.Index(totalizer);

            // Assert
            Assert.Equal(data, result.ViewData.Model);
            Assert.Equal(total, result.ViewData["Total"]);
        }
    }
}