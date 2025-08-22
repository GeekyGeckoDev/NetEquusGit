using Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.HorseRelatedRepositories.HorseRepository
{
    public class FoalingCrudRepository : IFoalingCrudRepository
    {
        private readonly NetEquusDbContext _context;

        public FoalingCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateFoalingAsync(Foaling foaling)
        {
            await _context.Foalings.AddAsync(foaling);
            await _context.SaveChangesAsync();
        }
        
        public async Task<Foaling?> GetFoalingByIdAsync (int foalingId)
        {
            return await _context.Foalings.FindAsync(foalingId);

        }

        public async Task UpdateFoalingAsync (Foaling foaling)
        {
             _context.Foalings.Update(foaling);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoalingAsync (Foaling foaling)
        {
            _context.Foalings.Remove(foaling);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync ()
        {
            await _context.SaveChangesAsync();
        }
    }
}
