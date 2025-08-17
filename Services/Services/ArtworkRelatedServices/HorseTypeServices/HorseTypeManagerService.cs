using Application.ServiceInterfaces;
using Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeServices;
using Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeSubmissionServices;
using Application.ServiceInterfaces.IUserRelatedServices.IHorseArtistService;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ArtworkRelatedServices.HorseTypeServices
{
    public class HorseTypeManagerService
    {
        private readonly IHorseTypeValidationService _horseTypeValidationService;

        private readonly IHorseTypeCrudService _horseTypeCrudService;

        private readonly IHorseTypeSubmissionValidationService _horseTypeSubmissionValidationService;

        private readonly IBreedValidationService _breedValidationService;

        public HorseTypeManagerService(IHorseTypeValidationService horseTypeValidationService, IHorseTypeCrudService horseTypeCrudService, IHorseTypeSubmissionValidationService horseTypeSubmissionValidationService,
            IBreedValidationService breedValidationService)
        {
            _horseTypeValidationService = horseTypeValidationService;
            _horseTypeCrudService = horseTypeCrudService;
            _horseTypeSubmissionValidationService = horseTypeSubmissionValidationService;
            _breedValidationService = breedValidationService;
          
        }

        public async Task CreateAndValidateHorseTypeSubmissionAsync (HorseType horseType, int horseTypeSubmissionId)
        {
            await _horseTypeSubmissionValidationService.LoadAndValidateHorseTypeSubmission(horseTypeSubmissionId);

            await _breedValidationService.LoadAndValidateBreedAsync(horseTypeSubmissionId);

            await _horseTypeCrudService.CreateHorseTypeAsync(horseType);
        }

        public async Task<HorseType?> GetAndValidateHorseTypeByIdAsync (int horseTypeId)
        {
            await _horseTypeValidationService.ValidateAndLoadHorseTypeAsync(horseTypeId);

            return await _horseTypeCrudService.GetHorseTypeByIdAsync(horseTypeId);
        }

        public async Task UpdateAndValidateHorseTypeAsync (int horseTypeId, HorseType existingHorseType, HorseType updatedHorseType)
        {
            await _horseTypeValidationService.ValidateAndLoadHorseTypeAsync(horseTypeId);

            await _horseTypeCrudService.UpdateHorseTypeAsync(existingHorseType, updatedHorseType);

        }

        public async Task DeleteAndValidateHorseTypeAsync (HorseType horseType, int horseTypeId)
        {
            await _horseTypeValidationService.ValidateAndLoadHorseTypeAsync(horseTypeId);
            await _horseTypeCrudService.DeleteHorseTypeAsync(horseType);

        }

    }
}
