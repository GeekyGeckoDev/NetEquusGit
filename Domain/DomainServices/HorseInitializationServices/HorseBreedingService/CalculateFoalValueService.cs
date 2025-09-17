using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
namespace Domain.DomainServices.HorseInitializationServices.HorseBreedingService
{
    public class CalculateFoalValueService
    {
        public int CalculateFoalValue (Horse damHorse, Horse sireHorse)
        {
            var foalValue = (damHorse.Value + sireHorse.Value) / 2 / 2.2;

            return (int)foalValue;

        }
    }
}
