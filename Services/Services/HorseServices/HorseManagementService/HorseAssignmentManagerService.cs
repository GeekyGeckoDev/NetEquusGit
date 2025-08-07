using Application.Services.HorseServices.HorseValidationServices;
using Application.Services.HorseServices.HorseBoardingServices;
using Application.Services.HorseServices.HorseOwnershipServices;
using Application.ProviderInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HorseServices.HorseManagementService
{
    public class HorseAssignmentManagerService
    {
        private readonly HorseValidationService _horseValidationService;
        private readonly HorseOwnershipCrudService _horseOwnershipCrudService;
        private readonly HorseBoardingCrudService _horseBoardingCrudService;
        private readonly ISystemAccountProvider _systemAccountProvider;
    

        public HorseAssignmentManagerService(HorseValidationService horseValidationService, HorseOwnershipCrudService horseOwnershipCrudService, HorseBoardingCrudService horseBoardingCrudService, ISystemAccountProvider systemAccountProvider)
        {
            _horseValidationService = horseValidationService;
            _horseOwnershipCrudService = horseOwnershipCrudService;
            _horseBoardingCrudService = horseBoardingCrudService;
            _systemAccountProvider = systemAccountProvider;
        }
        public async Task AssignHorseToUserAndEstateAsync(DateTime startDate, Guid horseId, Guid userId, Guid estateId, bool isPermanentResidence)
        {
            await _horseOwnershipCrudService.CreateHorseOwnershipLinkAsync(horseId, userId);
            await _horseBoardingCrudService.CreateHorseBoardingLinkAsync(startDate, horseId, userId, estateId, isPermanentResidence);
        }

        public async Task AssignHorseToSystemAsync(Guid horseId)
        {
            var systemUserId = _systemAccountProvider.GetSystemUserId();
            var systemEstateId = _systemAccountProvider.GetSystemEstateId();
            // You currently don't have AssignHorseAsync with these parameters (no startDate).
            // You could create an overload or pass a default startDate here.
            await AssignHorseAsync(DateTime.UtcNow, horseId, systemUserId, systemEstateId, true);
        }


        //Wrapper for User and Estate
        public async Task AssignHorseAsync(DateTime startDate, Guid horseId, Guid userId, Guid estateId, bool isPermanentResidence = true)
        {
            await _horseOwnershipCrudService.CreateHorseOwnershipLinkAsync(horseId, userId);
            await _horseBoardingCrudService.CreateHorseBoardingLinkAsync(startDate, userId, estateId, horseId, isPermanentResidence);
        }
    }
}
