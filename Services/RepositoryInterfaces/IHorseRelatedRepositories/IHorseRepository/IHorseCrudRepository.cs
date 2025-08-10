using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository
{
    public interface IHorseCrudRepository
    {
        Task CreateHorseAsync(Horse horse);

        Task<Horse?> GetHorseByIdAsync(Guid horseGuidId);

        Task UpdateHorseAsync(Horse horse);

        Task DeleteHorseAsync(Horse horse);

        Task SaveChangesAsync();
    }
}
