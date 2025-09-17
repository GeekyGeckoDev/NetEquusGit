using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.DomainServices.RuleBookServices.HorseRuleServices.HorseDelegate_CheckAll;

namespace Domain.DomainServices.RuleBookServices.HorseRuleServices
{
    public class HorsePairRuleService
    {
        public static HorsePairRule NoInbreeding = (horse, partner) =>
    (horse.SireId == partner.GuidHorseId || horse.DamId == partner.GuidHorseId ||
     partner.SireId == horse.GuidHorseId || partner.DamId == horse.GuidHorseId)
        ? RuleResult.Fail("Direct parent-offspring breeding not allowed")
    : (horse.SireId != null && horse.SireId == partner.SireId) ||
      (horse.DamId != null && horse.DamId == partner.DamId)
        ? RuleResult.Fail("Sibling or half-sibling breeding not allowed")
    : (horse.Sire?.SireId == partner.SireId || horse.Sire?.SireId == partner.DamId ||
       horse.Sire?.DamId == partner.SireId || horse.Sire?.DamId == partner.DamId ||
       horse.Dam?.SireId == partner.SireId || horse.Dam?.SireId == partner.DamId ||
       horse.Dam?.DamId == partner.SireId || horse.Dam?.DamId == partner.DamId)
        ? RuleResult.Fail("Grandparent inbreeding not allowed")
    : RuleResult.Success();

        public static HorsePairRule NoCrossBreeding = static (horse, partner) =>
        (horse.Breeds != partner.Breeds)
        ? RuleResult.Fail("Different breeds cannot be bred (crossbreeding disabled") : RuleResult.Success();

    }
}
