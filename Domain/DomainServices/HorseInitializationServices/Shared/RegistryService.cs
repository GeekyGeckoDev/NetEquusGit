using Domain.Models.Horses.Breeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseInitializationServices.Shared
{
    public class RegistryService
    {
        private readonly LastBreedRegistry _lastBreedRegistry;

        public RegistryService(LastBreedRegistry lastBreedRegistry)
        {
            lastBreedRegistry = _lastBreedRegistry;
        }

        public static string GenerateHorseRegistryId(string breedInitials, int number)

        {
            string paddedNumber = number.ToString("D5");
            return breedInitials + paddedNumber;
        }
    }
}

