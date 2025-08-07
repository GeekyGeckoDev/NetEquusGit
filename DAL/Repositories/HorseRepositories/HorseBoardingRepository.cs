using Application.RepositoryInterfaces.IHorseRepositories;
using Domain.Models;
using Domain.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.HorseRepositories
{
    public class HorseBoardingRepository : IHorseBoardingRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseBoardingRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateHorseBoardingLinkAsync(HorseBoarding boardingLink)
        {
            await _context.HorseBoardings.AddAsync(boardingLink);
            await _context.SaveChangesAsync();
        }

        public async Task<HorseBoarding?> GetHorseBoardingByIdAsync (Guid horseboardingId) 
        { 
            return await _context.HorseBoardings.FindAsync(horseboardingId);
        }

        public async Task UpdateHorseBoardingAsync  (HorseBoarding horseBoarding)
        {
             _context.HorseBoardings.Update(horseBoarding);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteHorseBoardingAsync (HorseBoarding horseBoarding)
        {
            _context.HorseBoardings.Remove(horseBoarding);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
