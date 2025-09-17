using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseInitializationServices.HorseBreedingService
{
    public class HorseHeightService
    {
        public int GenerateHorseHeight (Horse damHorse, Horse sireHorse, Breed foalBreed)
        {
            

            var damHeight = damHorse.HorseHeight;
            var sireHeight = sireHorse.HorseHeight;

            Random rnd = new Random();

            int foalHeight = (damHeight + sireHeight) / 2 + rnd.Next(-5, 6);

            if (foalHeight > foalBreed.MinHeight || foalHeight < foalBreed.MinHeight)
            {
                foalHeight = Math.Clamp(foalHeight, foalBreed.MinHeight, foalBreed.MaxHeight);

            }
                return foalHeight;



        }

    }
}