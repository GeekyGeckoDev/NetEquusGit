using Application.RepositoryInterfaces.IUserRepositories;
using Application.ServiceInterfaces.ICombinedValidationService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CombinedValidationServices
{
    public class EstateOwnershipValidationService : IEstateOwnershipValidationService
    {
        private readonly IValidateUserOwnershipRepository _validateUserOwnershipRepository;

        public EstateOwnershipValidationService(IValidateUserOwnershipRepository userOwnershipRepository)
        {
            _validateUserOwnershipRepository = userOwnershipRepository;
        }

        public async Task ValidateUserOwnsEstateAsync(Guid userId, Guid equinwEstateId)
        {
            bool ownEstate = await _validateUserOwnershipRepository.UserOwnsEstateAsync(userId, equinwEstateId);

            if (!ownEstate)
            {
                throw new ValidationException("The user does not own this horse.");
            }
        }

    }
}
