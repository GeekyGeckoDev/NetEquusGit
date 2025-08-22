using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IBreedRepositories
{
    public  interface IBreedCrudRepository
    {
        Task CreateBreedAsync(Breed breed);

        Task<Breed> GetBreedByIdAsync(int breedId);

        Task UpdateBreedAsync(Breed breed);

        Task DeleteBreedAsync(Breed breed);

        Task SaveChangesAsync();
    }
}
