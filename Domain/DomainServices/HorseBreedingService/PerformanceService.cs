using Domain.Models;
using Domain.Models.Enums;
using Domain.Models.Horses.HorseStats;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseBreedingService
{
    public class PerformanceService
    {

        private readonly DetermineDamInheritance _determineDamInheritance;

        public PerformanceService(DetermineDamInheritance determineDamInheritance)
        {
            _determineDamInheritance = determineDamInheritance;
        }
    
        
        public PerformanceAttributes GeneratePerformanceFromParentsStats(
             PerformanceAttributes dam,
             PerformanceAttributes sire,
             PurposeType purposeType, PerformanceWeight breedWeights)
        {
            var damInheritance = _determineDamInheritance.GenerateDamInheritance(purposeType);

            var foal = new PerformanceAttributes();

            double[] damStats = { dam.Gaits, dam.Jumping, dam.Speed, dam.Agility, dam.Endurance, dam.Stride, dam.Trainability };
            double[] sireStats = { sire.Gaits, sire.Jumping, sire.Speed, sire.Agility, sire.Endurance, sire.Stride, sire.Trainability };
            double[] foalStats = new double[damStats.Length];

            double[] weights = {
            breedWeights.GaitsWeight,
            breedWeights.JumpingWeight,
            breedWeights.SpeedWeight,
            breedWeights.AgilityWeight,
            breedWeights.EnduranceWeight,
            breedWeights.StrideWeight,
            breedWeights.TrainabilityWeight
        };

            Random rnd = new Random();

            for (int i = 0; i < damStats.Length; i++)
            {
                double damPortion = damStats[i] * 0.7;
                double sirePortion = sireStats[i] * 0.3;

                // apply inheritance multipliers
                if (i == 6) // Trainability is index 6, not 7
                    damPortion *= damInheritance.BaseStatInheritanceMultiplier;
                else
                    damPortion *= damInheritance.TrainingPointInheritanceMultiplier;

                // apply breed weight to the combined stat
                foalStats[i] = (damPortion + sirePortion) * weights[i] + (rnd.NextDouble() - 0.5);
            }


            // --- Fix low stats (at least 2 ≥ 5)
            int countBelow5 = foalStats.Count(s => s < 5);
            if (countBelow5 > 0)
            {
                var indexes = Enumerable.Range(0, foalStats.Length).Where(i => foalStats[i] < 5).ToList();
                int numToRaise = rnd.Next(1, Math.Min(2, indexes.Count) + 1);

                for (int j = 0; j < numToRaise; j++)
                {
                    int index = indexes[rnd.Next(indexes.Count)];
                    foalStats[index] = 5 + rnd.NextDouble();
                    indexes.Remove(index);
                }
            }

            // --- Apply cap
            double sum = foalStats.Sum();
            if (sum > 52)
            {
                double scale = 52 / sum;
                for (int i = 0; i < foalStats.Length; i++)
                    foalStats[i] *= scale;
            }

            // --- Assign back to object
            foal.Gaits = foalStats[0];
            foal.Jumping = foalStats[1];
            foal.Speed = foalStats[2];
            foal.Agility = foalStats[3];
            foal.Endurance = foalStats[4];
            foal.Stride = foalStats[5];
            foal.Trainability = foalStats[6];

            return foal;
        }
    }
}
