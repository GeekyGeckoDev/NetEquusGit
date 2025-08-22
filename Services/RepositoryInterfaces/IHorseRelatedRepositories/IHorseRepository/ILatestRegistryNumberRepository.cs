using Domain.Models;
using Domain.Models.Horses.Breeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository
{
    public interface ILatestRegistryNumberRepository
    {
        Task CreateLatestBreedRegistry(LastBreedRegistry lastBreedRegistry);

        Task<int> GetLatestBreedRegistryByBreed(Breed breed);

        Task UpdateLatestBreedRegistry(LastBreedRegistry lastBreedRegistry);

        Task DeleteLatestRegistry(LastBreedRegistry lastBreedRegistry);
    }
}
