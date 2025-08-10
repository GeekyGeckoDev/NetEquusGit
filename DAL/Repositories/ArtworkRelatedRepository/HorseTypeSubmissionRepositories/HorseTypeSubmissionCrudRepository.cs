using Application.RepositoryInterfaces.IArtworkRelatedRepository.IHorseTypeSubmissionRepositories;
using Domain.Models;
using Infrastructure.Repositories.ArtworkRelatedRepository.HorseTypeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ArtworkRelatedRepository.HorseTypeSubmissionRepositories
{
    public class HorseTypeSubmissionCrudRepository : IHorseTypeSubmissionRepository
    {
        private readonly NetEquusDbContext _context;

        public HorseTypeSubmissionCrudRepository(NetEquusDbContext context)
        {
            _context = context;
        }

        public async Task CreateHorseTypeSubmissionAsync (HorseTypeSubmission horseTypeSubmission)
        {
            await _context.AddAsync(horseTypeSubmission);

            await _context.SaveChangesAsync();
        }

        public async Task<HorseTypeSubmission> GetHorseTypeSubmisionByIdAsync (int horseTypeSubmissionId)
        {
            return await _context.HorseTypeSubmissions.FindAsync(horseTypeSubmissionId);
        }

        public async Task UpdateHorseTypeSubmissionAsync (HorseTypeSubmission horseTypeSubmission)
        {
            _context.HorseTypeSubmissions.Update(horseTypeSubmission);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHorseTypeSubmissionAsync (HorseTypeSubmission horseTypeSubmission)
        {
            _context.HorseTypeSubmissions.Remove(horseTypeSubmission);

            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
