using System.Collections.Generic;
using MyMinimalApi.Data.Models;

namespace MyMinimalApi.Services {
    public interface IPetService {
        Task<IEnumerable<Pet>> GetPets();
        Task<Pet> GetPet(int id);
        Task<Pet> AddPet(Pet pet);
        Task<Pet> UpdatePet(Pet pet);
        Task DeletePet(int id);
    }
}
