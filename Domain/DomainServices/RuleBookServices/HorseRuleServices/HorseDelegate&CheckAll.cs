using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.RuleBookServices.HorseRuleServices
{
    public class HorseDelegate_CheckAll
    {
        public delegate RuleResult GeneralHorseRule(Horse horse);
        public delegate RuleResult EligibleForBreedingRule (Horse horse);
        public delegate RuleResult HorsePairRule(Horse damHorse, Horse sireHorse);

        public static RuleResult CheckAll(Horse horse, IEnumerable<GeneralHorseRule> rules)
        {
            foreach (var rule in rules)
            {
                var result = rule(horse);
                if (!result.IsAllowed)
                    return result;
            }
            return RuleResult.Success();
        }

        public static RuleResult CheckAll(Horse damHorse, Horse sireHorse, IEnumerable<HorsePairRule> rules)
        {
            foreach (var rule in rules)
            {
                var result = rule(damHorse, sireHorse);
                if (!result.IsAllowed)
                {
                    return result;
                }
            }

            return RuleResult.Success();
        }
    }
}
