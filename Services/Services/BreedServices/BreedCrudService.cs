using Application.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Horses.Breeds;
using Domain.Models;
using Application.RepositoryInterfaces.IHorseRelatedRepositories;

namespace Application.Services.BreedServices
{
    public  class BreedCrudService
    {
        private readonly IBreedCrudRepository _breedCrudRepository;

        public BreedCrudService(IBreedCrudRepository breedCrudRepository)
        {
            _breedCrudRepository = breedCrudRepository;
        }

        public async Task CreateBreedAsync (Breed breed)
        {
            await _breedCrudRepository.CreateBreedAsync (breed);
            await _breedCrudRepository.SaveChangesAsync ();
        }

        public async Task<Breed> GetBreedByIdAsync (int breedId)
        {
            return await _breedCrudRepository.GetBreedByIdAsync(breedId);
        }

        public async Task UpdateBreedAsync (Breed existingBreed, Breed updatedBreed)
        {
            existingBreed.BreedName = updatedBreed.BreedName;

            await _breedCrudRepository.UpdateBreedAsync(existingBreed);
            await _breedCrudRepository.SaveChangesAsync();
        }

        public async Task DeleteBreedAsync (Breed breed)
        {
            await _breedCrudRepository.DeleteBreedAsync (breed);
            await _breedCrudRepository.SaveChangesAsync();
        }
    }
}

