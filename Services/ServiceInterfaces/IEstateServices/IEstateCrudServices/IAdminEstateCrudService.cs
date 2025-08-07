using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IEstateServices.IEstateManagementServices
{
    public interface IAdminEstateCrudService
    {
       

        Task DeleteEstateAsync(EquineEstate equineEstate);

    }
}
