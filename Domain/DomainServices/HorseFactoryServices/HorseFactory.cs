using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DomainServices.HorseInitializationServices;
using Domain.DomainServices.HorseInitializationServices.HorseBreedingService;
using Domain.DomainServices.HorseInitializationServices.Shared;
using Domain.DomainServices.LifecycleServices;
using Domain.Models;

namespace Domain.DomainServices.HorseFactoryServices
{
    public class HorseFactory
    {
        public Horse CreateNewFoal (Horse foal, Foaling foaling)
        {
            var Createdhorse = new Horse
            {
                GuidHorseId = Guid.NewGuid(),
                BirthDate = foaling.FoalingDate
                



               
            };

            return foal;
        }
    }
}
