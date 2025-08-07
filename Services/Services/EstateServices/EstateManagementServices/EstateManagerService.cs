using Application.ServiceInterfaces.IEstateServices.IEstateManagementServices;
using Application.ServiceInterfaces.IEstateServices.IEstateOwnershipServices;
using Application.ServiceInterfaces.IEstateServices.IEstateValidationServices;
using Domain.Models;
using Domain.Models.EquineEstates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EstateServices.EstateManagementServices
{
    public class EstateManagerService
    {
        private readonly IUserEstateCrudService _userEstateCrudService;
        private readonly IUserEstateOwnershipService _userOwnershipService;
        private readonly ISharedEstateCrudService _sharedEstateCrudService;
        private readonly IEstateValidationService _estateValidationService;

        public EstateManagerService(IUserEstateCrudService userEstateCrudService, IUserEstateOwnershipService userOwnershipService, ISharedEstateCrudService sharedEstateCrudService, IEstateValidationService estateValidationService)
        {
            _userEstateCrudService = userEstateCrudService;
            _userOwnershipService = userOwnershipService;
            _sharedEstateCrudService = sharedEstateCrudService;
            _estateValidationService = estateValidationService;

        }

        public async Task CreateEstateForUserAsync (Guid userId, EquineEstate newEstate)
        {
            var existingEstate = await _sharedEstateCrudService.GetEstateByUserIdAsync(userId);
            if (existingEstate != null)
            {
                throw new InvalidOperationException("User already owns an estate.");
            }

            var estateId = await _userEstateCrudService.CreateEstateAsync(newEstate);

            await _userOwnershipService.LinkUserToEstateAsync(userId, estateId, isPrimaryOwner: true);
        }

        public async Task UpdateAndValidateEstateAsync(EquineEstate existingEstate, EquineEstate updatedEstate)
        {
            var validatedEstate = await _estateValidationService.LoadAndValidateEstateAsync(existingEstate.EquineEstateId);


            await _sharedEstateCrudService.UpdateEstateAsync(existingEstate, updatedEstate);


        }

    }
}

