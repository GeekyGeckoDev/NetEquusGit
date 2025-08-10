using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeServices
{
    public interface IHorseTypeCrudService
    {
        Task CreateHorseTypeAsync(HorseType horseType);

        Task<HorseType> GetHorseTypeByIdAsync(int horseTypeId);

        Task DeleteHorseTypeAsync(HorseType horseType);

        Task UpdateHorseTypeAsync(HorseType existingHorseType, HorseType updatedHorseType);

    }
}
