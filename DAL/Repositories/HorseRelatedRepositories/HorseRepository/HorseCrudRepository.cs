using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.HorseRelatedRepositories.HorseRepository
{
    public class HorseCrudRepository : IHorseCrudRepository
    {

        private readonly NetEquusDbContext _context;

        public HorseCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateHorseAsync(Horse horse)
        {
            await _context.Horses.AddAsync(horse);
            await _context.SaveChangesAsync();
        }

        public async Task<Horse?> GetHorseByIdAsync (Guid horseGuidId)
        {
            return await _context.Horses.FindAsync(horseGuidId);
        }

        public async Task UpdateHorseAsync (Horse horse)
        {
            _context.Horses.Update(horse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHorseAsync(Horse horse)
        {
            _context.Horses.Remove(horse);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

