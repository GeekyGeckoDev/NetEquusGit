using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UserRelatedRepositories.HorseArtistRepositories
{
    public class GetHorseArtistRepository
    {
        private readonly NetEquusDbContext _context;

        public GetHorseArtistRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task<HorseArtist?> GetHorseArtistByUser (Guid userId)
        {
            return await _context.HorseArtists
            .Include(ha => ha.User)
            .FirstOrDefaultAsync(ha => ha.UserId == userId);
        }
    }
}
