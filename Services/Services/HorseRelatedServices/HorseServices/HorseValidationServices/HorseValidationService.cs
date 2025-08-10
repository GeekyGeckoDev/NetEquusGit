using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository;
using Application.ServiceInterfaces.IHorseServices.IHorseValidationServices;
using Application.ServiceInterfaces.IUserServices.IUserValidationServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HorseRelatedServices.HorseServices.HorseValidationServices
{
    public class HorseValidationService : IHorseValidationService
    {
        private readonly IHorseCrudRepository _horseCrudRepository;

        public HorseValidationService(IHorseCrudRepository horseCrudRepository)
        {
            _horseCrudRepository = horseCrudRepository;
        }

        public async Task<Horse> LoadAndValidateHorseAsync(Guid horseGuidId)
        {
            var horse = await _horseCrudRepository.GetHorseByIdAsync(horseGuidId);
            if (horse == null) throw new Exception("Horse not found");
            return horse;
        }

        public void ValidateHorseData (Horse horse, bool isFoaling)
        {
            if (isFoaling)
                ValidateHorseDataForFoaling(horse);
            else
                ValidateHorseDataForAdminCreation(horse);
        }

        public void ValidateHorseDataForFoaling(Horse horse)
        {
            if (horse.Age != 0)
                throw new ValidationException("Foals from a foaling must be 0");

            if (horse.BirthDate <= DateOnly.FromDateTime(DateTime.UtcNow))
                throw new ValidationException("Foaling birthdate must be in the future");

            if (horse.HorseType == null)
                throw new ValidationException("Foals must have a horsetype");

            if (horse.IsFoal == false)
                throw new ValidationException("Only foals can result from foalings");

            if (horse.Archetype != 0)
                throw new ValidationException("Foals can´t have an archetype yet");

            if (horse.Value != 9000)
                throw new ValidationException("A foals base value is 9000");

            if (horse.IsActive == true)
                throw new ValidationException("Foals can´t be active until they are born");

        }

        public void ValidateHorseDataForAdminCreation (Horse horse)
        {
            if (horse.Age > 3)
                throw new ValidationException("Horses over the age of 3 can´t be manually created");


            if (horse.HorseType == null)
                throw new ValidationException("Horses or foals must have a horsetype");

            if (horse.Archetype != 0)
                throw new ValidationException("New horses or foals can´t have an archetype yet");

            if (horse.Value > 15000)
                throw new ValidationException("A horses highest base value is 15000");
        }

       

    }
}

