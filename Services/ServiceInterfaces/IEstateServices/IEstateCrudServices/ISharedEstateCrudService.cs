using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IEstateServices.IEstateManagementServices
{
    public interface ISharedEstateCrudService
    {
        Task UpdateEstateAsync(EquineEstate existingEstate, EquineEstate updatedEstate);

        Task<EquineEstate> GetEstateByIdAsync(Guid equineEstateId);

        Task<EquineEstate> GetEstateByUserIdAsync(Guid userId);
    }
}
