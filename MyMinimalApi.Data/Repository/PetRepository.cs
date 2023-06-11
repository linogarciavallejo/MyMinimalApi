using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMinimalApi.Data.Models;

namespace MyMinimalApi.Data.Repository {
    public class PetRepository : IPetRepository {

        public readonly PetContext _context;
        public PetRepository(PetContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Pet>> GetPetsAsync() {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet> GetPetAsync(int id) {
            return await _context.Pets.FindAsync(id);
        }

        public async Task<Pet> AddPetAsync(Pet pet) {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task<Pet> UpdatePetAsync(Pet pet) {
            _context.Entry(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task DeletePetAsync(int id) {
            var pet = await _context.Pets.FindAsync(id);
            if (pet != null) {
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
