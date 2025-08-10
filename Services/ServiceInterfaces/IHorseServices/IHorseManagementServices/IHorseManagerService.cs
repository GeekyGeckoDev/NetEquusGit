using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IHorseServices.IHorseManagementServices
{
    public interface IHorseManagerService
    {
        Task<Guid> CreateValidateAssignHorseAsync(Horse horse, Guid userId, Guid estateId, bool isFoaling, bool isPermanentResidence);

        Task<Horse?> ValidateAndGetHorseById(Guid guidHorseId);

        Task UpdateAndValidateHorseAsync(Guid horseGuidId, Horse updatedHorse);

        Task ValidateOwnershipAndUpdateHorse(Horse existinghorse, Horse updatedHorse, Guid horseGuidId, Guid userId);

    }
}
