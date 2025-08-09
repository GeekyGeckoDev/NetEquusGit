using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IHorseServices
{
    public interface IHorseAssignmentManagerService
    {
        Task AssignHorseToUserAndEstateAsync(DateTime startDate, Guid horseId, Guid userId, Guid estateId, bool isPermanentResidence);

        Task AssignHorseToSystemAsync(Guid horseId);

        Task AssignHorseAsync(DateTime startDate, Guid horseId, Guid userId, Guid estateId, bool isPermanentResidence = true);
    }
}
