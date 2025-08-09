using Application.RepositoryInterfaces.IUserRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UserRepositories
{
    public  class ValidateUserOwnershipRepository : IValidateUserOwnershipRepository
    {
        private readonly NetEquusDbContext _context;

        public ValidateUserOwnershipRepository (NetEquusDbContext context)
        {  
            _context = context; 
        }

        public async Task<bool> UserOwnsHorseAsync(Guid userId, Guid horseId)
        {
            return await _context.Horses
                .Where(h => h.GuidHorseId == horseId)
                .SelectMany(h => h.HorseOwnerList)
                .AnyAsync(hol => hol.UserId == userId);
        }

        public async Task<bool> UserOwnsEstateAsync(Guid userId, Guid equineEstateId)
        {
            return await _context.EquineEstates
                .Where(e => e.EquineEstateId == equineEstateId)
                .SelectMany(e => e.EquineEstatesOwners)
                .AnyAsync(eeo => eeo.UserId == userId);
        }
    }
}
