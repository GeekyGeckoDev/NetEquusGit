using Application.RepositoryInterfaces.IEstateRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.EstateRepositories
{
    public class EstateCrudRepository : IEstateCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public EstateCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateEstateAsync(EquineEstate newEstate)
        {
            await _context.EquineEstates.AddAsync(newEstate);
            await _context.SaveChangesAsync(); // <-- this populates the ID
        }

        public async Task<EquineEstate?> GetEstateByIdAsync(Guid id)
        {
            return await _context.EquineEstates.FindAsync(id);
        }

        public async Task<EquineEstate> GetEstateByUserIdAsync (Guid userId)
        {
            return await _context.EquineEstates
                .Include(e => e.EquineEstatesOwners)
                .FirstOrDefaultAsync(e => e.EquineEstatesOwners
                .Any(owner => owner.UserId == userId));
        }

        public async Task UpdateEstateAsync(EquineEstate equineEstate)
        {
            _context.EquineEstates.Update(equineEstate); // Make sure EF is tracking this correctly
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstateAsync(EquineEstate equineEstate)
        {
            _context.EquineEstates.Remove(equineEstate);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
