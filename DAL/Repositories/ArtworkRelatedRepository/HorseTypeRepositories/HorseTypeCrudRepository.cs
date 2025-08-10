using Application.RepositoryInterfaces.IArtworkRelatedRepository.IHorseTypeRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ArtworkRelatedRepository.HorseTypeRepositories
{
    public class HorseTypeCrudRepository : IHorseTypeCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseTypeCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }
        public async Task CreateHorseTypeAsync (HorseType horseType)
        {
            await _context.HorseTypes.AddAsync (horseType);
            await _context.SaveChangesAsync ();
        }

        public async Task<HorseType> GetHorseTypeByIdAsync (int horseTypeId)
        {
            return await _context.HorseTypes.FindAsync(horseTypeId);
        }

        public async Task UpdateHorseTypeAsync(HorseType horseType)
        {
             _context.HorseTypes.Update(horseType);
            await _context.SaveChangesAsync ();
        }

        public async Task DeleteHorseTypeAsync (HorseType horseType)
        {
             _context.HorseTypes.Remove(horseType);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
