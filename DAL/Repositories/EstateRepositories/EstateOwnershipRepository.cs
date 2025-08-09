using Application.RepositoryInterfaces.IEstateRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.EstateRepositories
{
    public class EstateOwnershipRepository : IEstateOwnershipRepository
    {
        private readonly NetEquusDbContext _context;

        public EstateOwnershipRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateEstateOwnershipLinkAsync(EquineEstatesOwner ownershipLink)
        {
            await _context.EquineEstatesOwners.AddAsync(ownershipLink);
            await _context.SaveChangesAsync();
        }

        public async Task<EquineEstatesOwner?> GetEstsateOwnershipByIdAsync (Guid estateOwnershipId)
        {
            return await _context.EquineEstatesOwners.FindAsync(estateOwnershipId);
        }

        public async Task UpdateEstateOwnership(EquineEstatesOwner equineEstatesOwner)
        {
            _context.EquineEstatesOwners.Update(equineEstatesOwner);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstateOwnership (EquineEstatesOwner equineEstatesOwner)
        {
            _context.EquineEstatesOwners.Remove(equineEstatesOwner);

            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}