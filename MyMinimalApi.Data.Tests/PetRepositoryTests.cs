using MyMinimalApi.Data.Repository;
using MyMinimalApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MyMinimalApi.Data.Tests {
    public class PetRepositoryTests {
        private readonly PetContext _context;

        public PetRepositoryTests() {
            var options = new DbContextOptionsBuilder<PetContext>()
                .UseInMemoryDatabase(databaseName: "PetDb")
                .Options;

            _context = new PetContext(options);
        }

        [Fact]
        public async Task GetPet_ReturnsPet_WhenExists() { 
            //Arrange
            var pet = new Pet { Id = 1, Name = "Misha", Age = 8, Breed = "Himalayan", Color="White", Species="Cat", Notes="Misha" };
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            var petRepository = new PetRepository(_context);

            //Act
            var result = await petRepository.GetPetAsync(1);

            //Assert
            Assert.Equal(pet, result);
        }
    }
}