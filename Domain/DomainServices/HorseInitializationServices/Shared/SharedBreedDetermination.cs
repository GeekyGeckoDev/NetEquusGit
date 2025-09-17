using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseInitializationServices.Shared
{
    public class SharedBreedDetermination
    {
        public Task <List<Breed>> GetHorseBreedFromHorseType (HorseType horseType)
        {
            var breedList = new List<Breed> { horseType.Breed };

            return Task.FromResult(breedList);

        }
    }
}
