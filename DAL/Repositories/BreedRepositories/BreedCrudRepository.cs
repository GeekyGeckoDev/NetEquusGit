using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.BreedRepositories
{
    public class BreedCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public BreedCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateBreedAsync (Breed breed)
        {
            await _context.Breeds.AddAsync(breed);

            await _context.SaveChangesAsync();
        }

        public async Task<Breed?> GetBreedByIdAsync (int breedId)
        {
            return await _context.Breeds.FindAsync(breedId);
           
        }

        public async Task UpdateBreedAsync (Breed breed)
        {
            await _context.Breeds.AddAsync (breed);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteBreedAsync (Breed breed)
        {
             _context.Breeds.Remove(breed);

            await _context.SaveChangesAsync();
        }
    }
}