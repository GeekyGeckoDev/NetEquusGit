using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IUserRelatedServices.IUserServices.IUserManagementServices
{
    public interface IUserManagerService
    {
        Task UpdateAndValidateUserAsync(Guid userId, User updatedUserData);

    }
}
