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

        public async Task CreateOwnershipLinkAsync(EquineEstatesOwner ownershipLink)
        {
            await _context.EquineEstatesOwners.AddAsync(ownershipLink);
            await _context.SaveChangesAsync();
        }
    }
}
