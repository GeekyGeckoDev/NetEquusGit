using Domain.Models;
using Application.ServiceInterfaces;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Application.RepositoryInterfaces.IBreedRepositories;

namespace Application.Services.BreedServices
{
    public class BreedValidationService : IBreedValidationService
    {
        private readonly IBreedCrudRepository _breedCrudRepository;

        public BreedValidationService(IBreedCrudRepository breedCrudRepository)
        {
            _breedCrudRepository = breedCrudRepository;
        }

        public async Task<Breed> LoadAndValidateBreedAsync (int breedId)
        {
            var breed = await _breedCrudRepository.GetBreedByIdAsync (breedId);
            if (breed == null) throw new ValidationException("Breed not found");

            return breed;
        }
    }
}