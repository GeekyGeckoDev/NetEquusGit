using Domain.Models;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseInitializationServices.HorseBreedingService
{
    public class DetermineDamInheritance
    {


        public HorsePurposeStat GenerateDamInheritance(PurposeType damPurposeType, Horse damhorse)
        {

            damPurposeType = damhorse.HorsePurposeStat.PurposeType;


            switch (damPurposeType)
            {
                case PurposeType.Breeding:
                    return new HorsePurposeStat
                    {
                        BaseStatInheritanceMultiplier = 1.2,
                        TrainingPointInheritanceMultiplier = 1.0
                    };

                case PurposeType.Competition:
                    return new HorsePurposeStat
                    {
                        BaseStatInheritanceMultiplier = 1.0,
                        TrainingPointInheritanceMultiplier = 1.2
                    };

                case PurposeType.Mixed:
                default:
                    return new HorsePurposeStat
                    {
                        BaseStatInheritanceMultiplier = 1.0,
                        TrainingPointInheritanceMultiplier = 1.0
                    };
            }
        }
    }
}
