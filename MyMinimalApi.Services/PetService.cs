using MyMinimalApi.Data;
using MyMinimalApi.Data.Models;
using MyMinimalApi.Data.Repository;

namespace MyMinimalApi.Services {

    public class PetService : IPetService {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository) {
            _petRepository = petRepository;
        }

        public async Task<IEnumerable<Pet>> GetPets() => await _petRepository.GetPetsAsync();

        public async Task<Pet> GetPet(int id) => await _petRepository.GetPetAsync(id);

        public async Task<Pet> AddPet(Pet pet) => await _petRepository.AddPetAsync(pet);

        public async Task<Pet> UpdatePet(Pet pet) => await _petRepository.UpdatePetAsync(pet);

        public async Task DeletePet(int id) => await _petRepository.DeletePetAsync(id);

    }
}