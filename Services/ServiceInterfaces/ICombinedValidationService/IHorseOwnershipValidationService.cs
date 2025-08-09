using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.ICombinedValidationService
{
    public interface IHorseOwnershipValidationService
    {
        Task ValidateUserOwnsHorseAsync(Guid userId, Guid horseId);
    }
}
