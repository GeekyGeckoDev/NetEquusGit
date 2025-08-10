using Application.RepositoryInterfaces.IUserRepositories;
using Application.ServiceInterfaces.ICombinedValidationService;
using Application.ServiceInterfaces.IHorseServices.IHorseValidationServices;
using Application.ServiceInterfaces.IUserRelatedServices.IUserServices.IUserValidationServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CombinedValidationServices
{
    public class HorseOwnershipValidationService : IHorseOwnershipValidationService
    {
        private readonly IHorseValidationService _horseValidationService;
        private readonly IUserValidationService _userValidationService;
        private readonly IValidateUserOwnershipRepository _validateUserOwnershipRepository;


        public HorseOwnershipValidationService(IHorseValidationService horseValidationService, IUserValidationService userValidationService, IValidateUserOwnershipRepository validateUserOwnershipRepository)
        {
            _horseValidationService = horseValidationService;
            _userValidationService = userValidationService;
            _validateUserOwnershipRepository = validateUserOwnershipRepository;
        }

        public async Task ValidateUserOwnsHorseAsync(Guid userId, Guid horseId)
        {
            bool ownsHorse = await _validateUserOwnershipRepository.UserOwnsHorseAsync(userId, horseId);

            if (!ownsHorse)
            {
                throw new ValidationException("Thew user does not own this horse.");

            }
        }

        
    }
}
