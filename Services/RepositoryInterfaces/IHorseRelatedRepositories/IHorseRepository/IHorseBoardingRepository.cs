using Domain.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository
{
    public interface IHorseBoardingRepository
    {
        Task CreateHorseBoardingLinkAsync(HorseBoarding boardingLink);

        Task<HorseBoarding?> GetHorseBoardingByIdAsync(Guid horseboardingId);

        Task UpdateHorseBoardingAsync(HorseBoarding horseBoarding);

        Task DeleteHorseBoardingAsync(HorseBoarding horseBoarding);

        Task SaveChangesAsync();
    }
}
