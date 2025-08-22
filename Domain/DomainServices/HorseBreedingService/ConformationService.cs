using Domain.Models.Horses.HorseStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseBreedingService
{
    public class ConformationService
    {
        public static ConformationAttributes GenerateConformationFromParents(ConformationAttributes dam, ConformationAttributes sire, ConformationWeight conformationWeights)
        {
            var foal = new ConformationAttributes();

            Random rnd = new Random();

            double[] damMovement = { dam.Legs, dam.Shoulders, dam.Hindquarters, dam.Pasterns, dam.BackAndLoin };
            double[] sireMovement = { sire.Legs, sire.Shoulders, sire.Hindquarters, sire.Pasterns, sire.BackAndLoin };
            double[] foalMovement = new double[sireMovement.Length];

            double[] mWeights = { conformationWeights.LegsWeight, conformationWeights.ShouldersWeight, conformationWeights.HindquartersWeight, conformationWeights.PasternsWeight, conformationWeights.BackAndLoinWeight };

            for (int i = 0; i < damMovement.Length; i++)
            {

                foalMovement[i] = (damMovement[i] * 0.4) + (sireMovement[i] * 0.6) * mWeights[i]
                                  + (rnd.NextDouble() * 0.4 - 0.2); // adds random offset between -0.2 and +0.2
            }

            int mCountBelow5 = foalMovement.Count(m => m < 5);
            if (mCountBelow5 > 0)
            {
                var indexes = Enumerable.Range(0, foalMovement.Length).Where(i => foalMovement[i] < 5).ToList();
                int numToRaise = rnd.Next(1, Math.Min(2, indexes.Count) + 1);

                for (int j = 0; j < numToRaise; j++)
                {
                    int index = indexes[rnd.Next(indexes.Count)];
                    foalMovement[index] = 5 + rnd.NextDouble();
                    indexes.Remove(index);
                }
            }

            double mSum = foalMovement.Sum();
            if (mSum > 37)
            {
                double scale = 37 / mSum;
                for (int i = 0; i < foalMovement.Length; i++)
                    foalMovement[i] *= scale;
            }



            double[] damType = { dam.Head, dam.Neck, dam.ChestAndBarrel, dam.BackAndTopline, dam.OverallProportions };
            double[] sireType = { sire.Head, sire.Neck, sire.ChestAndBarrel, sire.BackAndTopline, sire.OverallProportions };
            double[] foalType = new double[damType.Length];

            double[] tWeights = { conformationWeights.HeadWeight, conformationWeights.NeckWeight, conformationWeights.ChestAndBarrelWeight, conformationWeights.BackAndToplineWeight, conformationWeights.OverallProportionsWeight };

            for (int i = 0; i < damType.Length; i++)
            {
                foalType[i] = (damType[i] * 0.6 + (sireType[i] * 0.4) * tWeights[i]
                    + (rnd.NextDouble() * 0.4 - 0.2));
            }

            int tCountBelow5 = foalType.Count(t => t > 5);
            if (tCountBelow5 > 0)
            {
                var indexes = Enumerable.Range(0, foalType.Length).Where(i => foalType[i] < 5).ToList();
                int numToRaise = rnd.Next(1, Math.Min(1, indexes.Count) + 1);

                for (int j = 0; j < numToRaise; j++)
                {
                    int index = indexes[rnd.Next(indexes.Count)];
                    foalType[index] = 5 + rnd.NextDouble();
                    indexes.Remove(index);
                }
            }

            double tSum = foalType.Sum();
            if (tSum > 37)
            {
                double scale = 37 / tSum;
                for (int i = 0; i < foalType.Length; i++)
                {
                    foalType[i] *= scale;
                }
            }


                // Combined cap

                var allConf = new List<double>
            {
                foal.Legs, foal.Shoulders, foal.Hindquarters, foal.Pasterns, foal.BackAndLoin,
                foal.Head, foal.Neck, foal.ChestAndBarrel, foal.BackAndTopline, foal.OverallProportions
            };

                var tens = allConf
                    .Select((value, index) => new { value, index })
                    .Where(x => x.value == 10)
                    .ToList();

                if (tens.Count > 3)
                {
                    rnd = new Random();
                    var toReduce = tens.OrderBy(x => rnd.Next()).Skip(3).ToList();

                    foreach (var t in toReduce)
                    {
                        allConf[t.index] = 9;
                    }


                }

                foal.Legs = allConf[0];
                foal.Shoulders = allConf[1];
                foal.Hindquarters = allConf[2];
                foal.Pasterns = allConf[3];
                foal.BackAndLoin = allConf[4];
                foal.Head = allConf[5];
                foal.Neck = allConf[6];
                foal.ChestAndBarrel = allConf[7];
                foal.BackAndTopline = allConf[8];
                foal.OverallProportions = allConf[9];
            return foal;
            }


        }
    }