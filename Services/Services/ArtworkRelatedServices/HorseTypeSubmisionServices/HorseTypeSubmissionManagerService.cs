using Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeSubmissionServices;
using Application.ServiceInterfaces.IUserRelatedServices.IHorseArtistService;
using Domain.Models;
using System.ComponentModel.DataAnnotations;

using Application.ServiceInterfaces;

namespace Application.Services.ArtworkRelatedServices.HorseTypeSubmisionServices
{
    public class HorseTypeSubmissionManagerService : IHorseTypeSubmissionManagerService
    {
        
        private readonly IHorseArtistValidationService _horseArtistValidationService;
        private readonly IHorseTypeSubmissionCrudService _horseTypeSubmissionCrudService;
        private readonly IBreedValidationService _breedValidationService;
        private readonly IHorseTypeSubmissionValidationService _horseTypeSubmissionValidationService;

        public HorseTypeSubmissionManagerService(IHorseArtistValidationService horseArtistValidationService, IHorseTypeSubmissionCrudService horseTypeSubmissionCrudService, IBreedValidationService breedValidationService,
            IHorseTypeSubmissionValidationService horseTypeSubmissionValidationService)
        {
            _horseArtistValidationService = horseArtistValidationService;
            _horseTypeSubmissionCrudService = horseTypeSubmissionCrudService;
            _breedValidationService = breedValidationService;
            _horseTypeSubmissionValidationService = horseTypeSubmissionValidationService;
        }
        public async Task<int> CreateCheckAndValidateHorseTypeSubmissionAsync(Guid userId, int breedId)
        {
            await _horseArtistValidationService.ValidateIsHorseArtist(userId);

            await _breedValidationService.LoadAndValidateBreedAsync(breedId);

            var horseTypeSubmission = new HorseTypeSubmission
            {
                SubmittedByUserId = userId,
                PictureRef = "someValue" // you’ll need to fill in required fields
            };

            if (string.IsNullOrWhiteSpace(horseTypeSubmission.PictureRef))
                throw new ValidationException("Picture reference is required.");

            return await _horseTypeSubmissionCrudService
                .CreateHorseTypeSubmissionAsync(horseTypeSubmission);

            
        }

        public async Task<HorseTypeSubmission> GetAndValidateHorseTypeSubmissionAsync (int horseTypeSubmissionId, HorseTypeSubmission horseTypeSubmission)
        {
            await _horseTypeSubmissionValidationService.LoadAndValidateHorseTypeSubmission(horseTypeSubmissionId);

            return await _horseTypeSubmissionCrudService.GetHorseTypeSubmissionByIdAsync(horseTypeSubmissionId);
        }

        public async Task UpdateAndValidateHorseTypeSubmissionAsync(int horseTypeSubmissionId, HorseTypeSubmission existinghorseTypeSubmission, HorseTypeSubmission updatedHorseTypeSubmission)
        {
            await _horseTypeSubmissionValidationService.LoadAndValidateHorseTypeSubmission(horseTypeSubmissionId);

            await _horseTypeSubmissionCrudService.UpdateHorseTypeSubmisionAsync(existinghorseTypeSubmission, updatedHorseTypeSubmission);
        }

        public async Task DeleteAndValidateHorseTypeSubmissionAsync (int horseTypeSubmissionId, HorseTypeSubmission horseTypeSubmission)
        {
            await _horseTypeSubmissionValidationService.LoadAndValidateHorseTypeSubmission(horseTypeSubmissionId);

            await _horseTypeSubmissionCrudService.DeleteHorseTypeSubmissionAsync(horseTypeSubmission);
        }
    }
}