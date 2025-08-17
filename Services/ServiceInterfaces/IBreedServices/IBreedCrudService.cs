using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IBreedServices
{
    public interface IBreedCrudService
    {
        Task CreateBreedAsync(Breed breed);

        Task<Breed> GetBreedByIdAsync(int breedId);

        Task UpdateBreedAsync(Breed existingBreed, Breed updatedBreed);

        Task DeleteBreedAsync(Breed breed);
    }
}
