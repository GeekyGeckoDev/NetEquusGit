
using Domain.Models;
using Application.ServiceInterfaces.IHorseServices.IHorseValidationServices;
using Application.ServiceInterfaces.IHorseServices.IHorseCrudServices;
using Application.ServiceInterfaces.IEstateServices.IEstateValidationServices;
using Application.ServiceInterfaces.ICombinedValidationService;
using Application.ServiceInterfaces.IHorseServices.IHorseManagementServices;
using Application.ServiceInterfaces.IUserRelatedServices.IUserServices.IUserValidationServices;




namespace Application.Services.HorseRelatedServices.HorseServices.HorseManagementService
{
    public class HorseManagerService : IHorseManagerService
    {
        private readonly IHorseValidationService _horseValidationService;
        private readonly ISharedHorseCrudService _sharedHorseCrudService;
        private readonly IUserValidationService _userValidationService;
        private readonly IEstateValidationService _estateValidationService;
        private readonly IAdminHorseCrudService _adminHorseCrudService;
        private readonly IHorseAssignmentManagerService _horseAssignmentManagerService;
        private readonly IHorseOwnershipValidationService _horseValidationOwnershipService;
        private readonly IUserHorseCrudService _userHorseCrudService;
        

        public HorseManagerService(IHorseValidationService horseValidationService, ISharedHorseCrudService sharedHorseCrudService, IUserValidationService userValidationService,
            IEstateValidationService estateValidationService, IAdminHorseCrudService adminHorseCrudService, IHorseAssignmentManagerService horseAssignmentManagerService, 
            IHorseOwnershipValidationService horseValidationOwnershipService, IUserHorseCrudService userHorseCrudService)
        {
            _horseValidationService = horseValidationService;
            _sharedHorseCrudService = sharedHorseCrudService;
            _userValidationService = userValidationService;
            _estateValidationService = estateValidationService;
            _adminHorseCrudService = adminHorseCrudService;
            _horseAssignmentManagerService = horseAssignmentManagerService;
            _horseValidationOwnershipService = horseValidationOwnershipService;
            _userHorseCrudService = userHorseCrudService;   
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

        public async Task<Horse?> ValidateAndGetHorseById(Guid guidHorseId)
        {
            await _horseValidationService.LoadAndValidateHorseAsync(guidHorseId);

            return await _sharedHorseCrudService.GetHorseByIdAsync(guidHorseId);
        }

        public async Task ValidateOwnershipAndUpdateHorse (Horse existinghorse, Horse updatedHorse, Guid horseGuidId, Guid userId)
        {
            
            await _horseValidationService.LoadAndValidateHorseAsync (horseGuidId);

            await _userValidationService.LoadAndValidateUserAsync(userId);

            await _horseValidationOwnershipService.ValidateUserOwnsHorseAsync(userId, horseGuidId);

            await _sharedHorseCrudService.UpdateHorseAsync(existinghorse,updatedHorse );
        }
    }
}
