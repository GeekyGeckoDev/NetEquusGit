using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IUserRelatedServices.IUserServices.IUserValidationServices
{
    public interface IUserValidationService
    {
        Task<User> LoadAndValidateUserAsync(Guid userId);
    }
}
