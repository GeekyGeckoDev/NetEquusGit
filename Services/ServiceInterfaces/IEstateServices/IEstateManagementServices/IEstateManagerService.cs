using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IEstateServices.IEstateManagementServices
{
    public interface IEstateManagerService
    {
        Task CreateEstateForUserAsync(Guid userId, EquineEstate newEstate);

        Task<EquineEstate?> ValidateAndGetEstateById(Guid equineEstateId);

        Task ValidateOwnershipAndUpdateEstateAsync(EquineEstate existingEstate, EquineEstate updatedEstate, Guid equineEstateId, Guid userId);
    }
}
