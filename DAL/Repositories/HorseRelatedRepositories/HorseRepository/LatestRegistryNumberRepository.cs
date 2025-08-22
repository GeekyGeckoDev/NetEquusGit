using Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository;
using Domain.Models;
using Domain.Models.Horses.Breeds;
using Infrastructure.Repositories.HorseRelatedRepositories.HorseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.HorseRelatedRepositories.HorseRepository
{
    public class LatestRegistryNumberRepository : ILatestRegistryNumberRepository
    {
        private readonly NetEquusDbContext _context;

        public LatestRegistryNumberRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateLatestBreedRegistry(LastBreedRegistry lastBreedRegistry)
        {
            await _context.LastBreedRegistries.AddAsync(lastBreedRegistry);
            await _context.SaveChangesAsync();

        }

        public async Task<int> GetLatestBreedRegistryByBreed(Breed breed)
        {
            var lastRegistry = await _context.LastBreedRegistries.FirstOrDefaultAsync(lr => lr.BreedId == breed.BreedId);

            return lastRegistry?.LastUsedNumber ?? 0;
        }

        public async Task UpdateLatestBreedRegistry(LastBreedRegistry lastBreedRegistry)
        {
            _context.LastBreedRegistries.Update(lastBreedRegistry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLatestRegistry(LastBreedRegistry lastBreedRegistry)
        {
            _context.LastBreedRegistries.Remove(lastBreedRegistry);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

