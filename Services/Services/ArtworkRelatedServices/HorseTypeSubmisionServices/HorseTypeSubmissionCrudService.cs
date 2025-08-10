using Application.RepositoryInterfaces.IArtworkRelatedRepository.IHorseTypeSubmissionRepositories;
using Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeSubmissionServices;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ArtworkRelatedServices.HorseTypeSubmisionServices
{
    public class HorseTypeSubmissionCrudService : IHorseTypeSubmissionCrudService
    {
        private readonly IHorseTypeSubmissionRepository _horseTypeSubmissionRepository;

        public HorseTypeSubmissionCrudService(IHorseTypeSubmissionRepository horseTypeSubmissionRepository)
        {
            _horseTypeSubmissionRepository = horseTypeSubmissionRepository;
        }

        public async Task<int> CreateHorseTypeSubmissionAsync (HorseTypeSubmission horseTypeSubmission)
        {
            await _horseTypeSubmissionRepository.CreateHorseTypeSubmissionAsync(horseTypeSubmission);
            await _horseTypeSubmissionRepository.SaveChangesAsync();

            return horseTypeSubmission.HorseTypeSubmissionID;
        }

        public async Task<HorseTypeSubmission?> GetHorseTypeSubmissionByIdAsync (int horseTypeSubmissionId)
        {
            return await _horseTypeSubmissionRepository.GetHorseTypeSubmisionByIdAsync(horseTypeSubmissionId);

        }

        public async Task UpdateHorseTypeSubmisionAsync (HorseTypeSubmission existinghorseTypeSubmission, HorseTypeSubmission updatedHorseTypeSubmission)
        {
            existinghorseTypeSubmission.BreedID = updatedHorseTypeSubmission.BreedID;

            await _horseTypeSubmissionRepository.UpdateHorseTypeSubmissionAsync(existinghorseTypeSubmission);

            await _horseTypeSubmissionRepository.SaveChangesAsync ();
        }

        public async Task DeleteHorseTypeSubmissionAsync (HorseTypeSubmission horseTypeSubmission)
        {
            await _horseTypeSubmissionRepository.DeleteHorseTypeSubmissionAsync(horseTypeSubmission);

            await _horseTypeSubmissionRepository.SaveChangesAsync();
        }
    }
}
