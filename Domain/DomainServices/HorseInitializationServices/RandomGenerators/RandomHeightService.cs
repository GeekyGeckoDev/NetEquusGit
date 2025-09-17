using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseInitializationServices.RandomGenerators
{
    public class RandomHeightService
    {
        public int RandomHeight (Breed breed)
        {
            Random random = new Random ();
            int height = random.Next (breed.MinHeight, breed.MaxHeight);
            return height;


        }
    }
}