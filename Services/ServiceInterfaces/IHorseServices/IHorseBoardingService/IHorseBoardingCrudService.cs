using Domain.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IHorseServices.IHorseBoardingService
{
    public interface IHorseBoardingCrudService
    {
        Task CreateHorseBoardingLinkAsync(DateTime StartDate, Guid userId, Guid estateId, Guid guidHorseId, bool IsPermanentResidence);

        Task<HorseBoarding?> GetHorseBoardingByIdAsync(Guid horseBoardingId);

        Task UpdateHorseBoardingAsync(HorseBoarding existinghorseBoarding, HorseBoarding updatedHorseBoarding);

        Task DeleteHorseBoardingAsync(HorseBoarding horseBoarding);
    }
}
