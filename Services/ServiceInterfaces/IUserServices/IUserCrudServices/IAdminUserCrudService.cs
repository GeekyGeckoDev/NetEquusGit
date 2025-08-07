using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IUserServices.IUserManagementServices
{
    public interface IAdminUserCrudService
    {
        Task CreateUserAsync(User user);

        Task DeleteUserAsync(User user);




    }
}
