using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IEstateServices.IEstateManagementServices
{
    public interface IUserEstateCrudService
    {
        Task<Guid> CreateEstateAsync(EquineEstate newEstate);
    }
}
