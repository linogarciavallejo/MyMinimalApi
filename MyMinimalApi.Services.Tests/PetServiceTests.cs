using System.Threading.Tasks;
using MyMinimalApi.Data;
using MyMinimalApi.Data.Models;
using MyMinimalApi.Services;
using Xunit;
using System.Diagnostics.Eventing.Reader;
using MyMinimalApi.Data.Repository;
using Moq;

namespace MyMinimalApi.Services.Tests {
    public class PetServiceTests {
        private readonly Mock<IPetRepository> _mockPetRepository;

        public PetServiceTests() {
            _mockPetRepository = new Mock<IPetRepository>();
        }

        [Fact]
        public async Task GetPet_ReturnsPet_WhenExists() {
            // Arrange
            var pet = new Pet { Id = 1, Name = "Fido", Age = 3 };
            _mockPetRepository.Setup(r => r.GetPetAsync(1)).ReturnsAsync(pet);

            var petService = new PetService(_mockPetRepository.Object);

            // Act
            var result = await petService.GetPet(1);

            // Assert
            Assert.Equal(pet, result);
        }

        // Add more tests as needed...
    }
}
