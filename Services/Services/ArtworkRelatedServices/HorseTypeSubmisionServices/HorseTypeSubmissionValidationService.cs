using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IArtworkRelatedRepository.IHorseTypeRepository;
using Application.RepositoryInterfaces.IArtworkRelatedRepository.IHorseTypeSubmissionRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ArtworkRelatedServices.HorseTypeSubmisionServices
{
    public class HorseTypeSubmissionValidationService
    {
        private readonly IHorseTypeSubmissionRepository _horseTypeSubmissionCrudRepository;

        public HorseTypeSubmissionValidationService(IHorseTypeSubmissionRepository horseTypeSubmissionCrudRepository)
        {
            _horseTypeSubmissionCrudRepository = horseTypeSubmissionCrudRepository;
        }

        public async Task<HorseTypeSubmission> LoadAndValidateHorseTypeSubmission(int horseTypeSubmissionId)
        {
            var horseTypeSubmission = await _horseTypeSubmissionCrudRepository.GetHorseTypeSubmisionByIdAsync(horseTypeSubmissionId);
            if (horseTypeSubmission == null) throw new ValidationException("HorseTypeSubmission not found");

            return horseTypeSubmission;
        }
    }
}