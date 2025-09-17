using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Enums;
using static Domain.DomainServices.RuleBookServices.HorseRuleServices.HorseDelegate_CheckAll;

namespace Domain.DomainServices.RuleBookServices.HorseRules
{
    public class BreedingRuleService
    {
        public static EligibleForBreedingRule Mature = (horse) =>
        horse.Age >= 3 ? RuleResult.Success() : RuleResult.Fail("Horses must be at least 3 years old to breed");

        public static EligibleForBreedingRule DamNotInFoal = (horse) =>
        horse.HorseGender == 0 && horse.InFoal == false ? RuleResult.Success() : RuleResult.Fail("Mare is already in foal");

        public static EligibleForBreedingRule DamPurposeType = (horse) =>
        new[] { PurposeType.Breeding, PurposeType.Mixed }
            .Contains(horse.HorsePurposeStat.PurposeType)
            ? RuleResult.Success()
            : RuleResult.Fail("Competition mares can't be bred");
    }
}