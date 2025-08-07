using Application.Services.HorseServices.HorseCrudServices;
using Application.Services.HorseServices.HorseValidationServices;
using Application.Services.UserServices.UserValidationServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Application.Services.EstateServices.EstateValidationServices;

namespace Application.Services.HorseServices.HorseManagementService
{
    public class HorseManagerService
    {
        private readonly HorseValidationService _horseValidationService;
        private readonly SharedHorseCrudService _sharedHorseCrudService;
        private readonly UserValidationService _userValidationService;
        private readonly EstateValidationService _estateValidationService;
        private readonly AdminHorseCrudService _adminHorseCrudService;
        private readonly HorseAssignmentManagerService _horseAssignmentManagerService;
        

        public HorseManagerService(HorseValidationService horseValidationService, SharedHorseCrudService sharedHorseCrudService, UserValidationService userValidationService,
            EstateValidationService estateValidationService, AdminHorseCrudService adminHorseCrudService, HorseAssignmentManagerService horseAssignmentManagerService)
        {
            _horseValidationService = horseValidationService;
            _sharedHorseCrudService = sharedHorseCrudService;
            _userValidationService = userValidationService;
            _estateValidationService = estateValidationService;
            _adminHorseCrudService = adminHorseCrudService;
            _horseAssignmentManagerService = horseAssignmentManagerService;
        }



        public async Task UpdateAndValidateHorseAsync (Guid horseGuidId, Horse updatedHorse)
        {
            var existingHorse = await _horseValidationService.LoadAndValidateHorseAsync(horseGuidId);
            await _sharedHorseCrudService.UpdateHorseAsync(existingHorse, updatedHorse);    
        }

        public async Task<Guid>CreateValidateAssignHorseAsync(Horse horse, Guid userId, Guid estateId, bool isFoaling, bool isPermanentResidence)
        {
             _horseValidationService.ValidateHorseData(horse, isFoaling);
            
            await _userValidationService.LoadAndValidateUserAsync(userId); 

            await _estateValidationService.LoadAndValidateEstateAsync(estateId);
            
            var guidHorseId = await _adminHorseCrudService.CreateHorseAsync(horse);

            await _horseAssignmentManagerService.AssignHorseToUserAndEstateAsync(DateTime.UtcNow, guidHorseId, userId, estateId, isPermanentResidence);

            return guidHorseId;

        }
    }
}
