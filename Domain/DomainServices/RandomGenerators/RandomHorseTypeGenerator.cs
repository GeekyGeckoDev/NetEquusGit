using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.RandomGenerators
{
    public class RandomHorseTypeGenerator
    {
        public HorseType GetRandomHorseType(IEnumerable<HorseType> allHorseTypes, int? breedId = null)
        {
            IEnumerable<HorseType> pool = allHorseTypes;

            if (breedId.HasValue)
                pool = pool.Where(ht => ht.BreedId == breedId.Value);

            var horseTypesList = pool.ToList();
            if (!horseTypesList.Any())
                return null;

            Random rnd = new Random();
            return horseTypesList[rnd.Next(horseTypesList.Count)];
        }
    }
}
