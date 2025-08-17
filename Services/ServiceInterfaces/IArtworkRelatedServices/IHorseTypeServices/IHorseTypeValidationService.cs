using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeServices
{
    public interface IHorseTypeValidationService
    {
        Task<HorseType> ValidateAndLoadHorseTypeAsync(int horseTypeId);
    }
}
