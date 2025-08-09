using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IHorseServices.IHorseCrudServices
{
    public interface ISharedHorseCrudService
    {
        Task UpdateHorseAsync(Horse existingHorse, Horse updatedHorse);

        Task<Horse> GetHorseByIdAsync(Guid horseGuidId);
    }
}
