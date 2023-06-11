using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMinimalApi.Data.Models;

namespace MyMinimalApi.Data.Repository {
    public interface IPetRepository {
        Task<IEnumerable<Pet>> GetPetsAsync();
        Task<Pet> GetPetAsync(int id);
        Task<Pet> AddPetAsync(Pet pet);
        Task<Pet> UpdatePetAsync(Pet pet);
        Task DeletePetAsync(int id);
    }
}
