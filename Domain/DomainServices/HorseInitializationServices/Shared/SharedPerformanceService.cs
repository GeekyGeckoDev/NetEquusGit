using Domain.Models.Horses.HorseStats;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseInitializationServices.Shared
{
    public class SharedPerformanceService
    {
        private static Random rnd = new Random();

        private double RandomOffset(double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }
            public void GeneratePerformanceStats(PerformanceAttributes performanceAttributes, PerformanceAttributes minStats, PerformanceAttributes maxStats, PerformanceWeight breedWeights)
            {
                double[] newStats = new double[7];

                double[] min = { minStats.Gaits, minStats.Jumping, minStats.Speed, minStats.Agility, minStats.Endurance, minStats.Stride, minStats.Trainability };
                double[] max = { maxStats.Gaits, maxStats.Jumping, maxStats.Speed, maxStats.Agility, maxStats.Endurance, maxStats.Stride, maxStats.Trainability };

                double[] weights = {      breedWeights.GaitsWeight,
                breedWeights.JumpingWeight,
                breedWeights.SpeedWeight,
                breedWeights.AgilityWeight,
                breedWeights.EnduranceWeight,
                breedWeights.StrideWeight,
                breedWeights.TrainabilityWeight};

                for (int i = 0; i < 7; i++)
                {
                    // Pick random starting point between min and max
                    double value = rnd.NextDouble() * (max[i] - min[i]) + min[i] * weights[i];

                    // Apply a small random variation (+/- 0.5)
                    value += RandomOffset(-0.5, 0.5);

                    // Clamp to min/max just in case offset went out of bounds
                    newStats[i] = Math.Clamp(value, min[i], max[i]);
                }

                // Step 2: ensure at least 2 stats >= 5
                var lowIndexes = Enumerable.Range(0, newStats.Length).Where(i => newStats[i] < 5).ToList();
                int toRaise = Math.Min(2, lowIndexes.Count);
                for (int i = 0; i < toRaise; i++)
                {
                    int index = lowIndexes[rnd.Next(lowIndexes.Count)];
                    newStats[index] = 5 + rnd.NextDouble();
                    lowIndexes.Remove(index);
                }

                // Step 3: apply overall cap of 50
                double sum = newStats.Sum();
                if (sum > 49)
                {
                    double scale = 49 / sum;
                    for (int i = 0; i < newStats.Length; i++)
                        newStats[i] *= scale;
                }

                // Step 4: map back to performanceAttributes
                performanceAttributes.Gaits = newStats[0];
                performanceAttributes.Jumping = newStats[1];
                performanceAttributes.Speed = newStats[2];
                performanceAttributes.Agility = newStats[3];
                performanceAttributes.Endurance = newStats[4];
                performanceAttributes.Stride = newStats[5];
                performanceAttributes.Trainability = newStats[6];

            }
    }
}