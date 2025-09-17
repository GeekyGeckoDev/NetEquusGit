using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseInitializationServices.HorseBreedingService
{
    public class DetermineHorseBreed
    {
        public Task <List<Breed>> GetHorseBreedsFromParents (Horse damHorse, Horse sireHorse)
        {;
           damHorse.Breeds.Add((Breed)sireHorse.Breeds);

            return (Task<List<Breed>>)damHorse.Breeds;
        }
    }
}


//public Task<List<Breed>> GetHorseBreedFromHorseType(HorseType horseType)
//{
//    var breedList = new List<Breed> { horseType.Breed };

//    return Task.FromResult(breedList);

//}