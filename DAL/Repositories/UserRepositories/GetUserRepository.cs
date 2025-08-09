using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UserRepositories
{
    public class GetUserRepository
    {

        private readonly NetEquusDbContext _context;

        public GetUserRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersByHorseId(Guid horseId)
        {
            return await _context.Horses
                .Where(h => h.GuidHorseId == horseId)
                .SelectMany(h => h.HorseOwnerList)
                .Select(hol => hol.user)
                .ToListAsync();
        }
    }
}
