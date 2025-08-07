using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IEstateServices.IEstateOwnershipServices
{
    public interface IUserEstateOwnershipService
    {
        Task LinkUserToEstateAsync(Guid userId, Guid estateId, bool isPrimaryOwner);
    }
}
