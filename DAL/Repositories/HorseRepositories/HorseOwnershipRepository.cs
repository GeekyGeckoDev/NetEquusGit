using Application.RepositoryInterfaces.IEstateRepositories;
using Application.RepositoryInterfaces.IHorseRepositories;
using Domain.Models;
using Domain.Models.Horses;
using Domain.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.HorseRepositories
{
    public class HorseOwnershipRepository : IHorseOwnershipRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseOwnershipRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateHorseOwnershipLinkAsync(HorseOwnership ownershipLink)
        {
            await _context.HorseOwnerships.AddAsync(ownershipLink);
            await _context.SaveChangesAsync();

        }

        public async Task<HorseOwnership?> GetHorseOwnershipByIdAsync (Guid horseOwnershipId)
        {
            return await _context.HorseOwnerships.FindAsync(horseOwnershipId);

        }

        public async Task UpdateHorseOwnershipAsync (HorseOwnership horseOwnership)
        {
            _context.HorseOwnerships.Update(horseOwnership);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHorseOwnershipAsync (HorseOwnership horseOwnership)
        {
            _context.HorseOwnerships.Remove(horseOwnership);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
