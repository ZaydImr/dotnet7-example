using SuperHero.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.UnitTests.Systems.Controllers
{
    public class TestSuperHeroController
    {
        private readonly SuperHeroController _controller;

        public TestSuperHeroController(SuperHeroController controller)
        {
            _controller = controller;
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            // Act
            //var result = (await _controller.GetSuperHeroes() as OkObjectResult).StatusCode as int;

            // Assert
            //result.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvoikesUserService()
        {
            // Arrange
            //var sut = new UsersController();

            // Act
            ///var result = (OkObjectResult)await sut.Get();

            // Assert
            //result.StatusCode.Should().Be(200);
        }
    }
}