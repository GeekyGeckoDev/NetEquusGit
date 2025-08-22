using Domain.Models.Horses.HorseStats;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseInitializationServices.Shared
{
    public class SharedConformationService
    {
        private static Random rnd = new Random();

        private double RandomOffSet(double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }

        public void GenerateConformationStats(ConformationAttributes conformationAttributes, ConformationAttributes minConf, ConformationAttributes maxConf, ConformationWeight confWeights)
        {
            double[] newMovConf = new double[5];

            double[] minM = { minConf.Legs, minConf.Shoulders, minConf.Hindquarters, minConf.Pasterns, minConf.BackAndLoin };
            double[] maxM = { maxConf.Legs, maxConf.Shoulders, maxConf.Hindquarters, maxConf.Pasterns, maxConf.BackAndLoin };

            double[] mWeights = { confWeights.LegsWeight, confWeights.ShouldersWeight, confWeights.HindquartersWeight, confWeights.PasternsWeight, confWeights.BackAndLoinWeight };

            for (int i = 0; i < 5; i++)
            {
                double value = (rnd.NextDouble() * (maxM[i] - minM[i]) + minM[i]) * mWeights[i];
                value += RandomOffSet(-0.5, 0.5);

                newMovConf[i] = Math.Clamp(value, minM[i], maxM[i]);


            }

            int mCountntBelow5 = newMovConf.Count(m => m < 5);
            if (mCountntBelow5 > 0)
            {
                var indexes = Enumerable.Range(0, newMovConf.Length).Where(i => newMovConf[i] < 5).ToList();
                int numToRaise = rnd.Next(1, Math.Min(1, indexes.Count) + 1);

                for (int j = 0; j < numToRaise; j++)
                {
                    int index = indexes[rnd.Next(indexes.Count)];
                    newMovConf[index] = 5 + rnd.NextDouble();
                    indexes.Remove(index);
                }

            }


            double mSum = newMovConf.Sum();
            if (mSum > 35)
            {
                double scale = 35 / mSum;
                for (int i = 0; i < newMovConf.Length; i++)
                    newMovConf[i] *= scale;

            }


            double[] newTypConf = new double[5];

            double[] minT = { minConf.Head, minConf.Neck, minConf.ChestAndBarrel, minConf.BackAndTopline, minConf.OverallProportions };
            double[] maxT = { maxConf.Head, maxConf.Neck, maxConf.ChestAndBarrel, maxConf.BackAndTopline, maxConf.OverallProportions };

            double[] tWeights = { confWeights.HeadWeight, confWeights.NeckWeight, confWeights.ChestAndBarrelWeight, confWeights.BackAndToplineWeight, confWeights.OverallProportionsWeight };

            for (int i = 0; i < 5; i++)
            {
                double value = (rnd.NextDouble() * (maxM[i] - minM[i]) + minM[i]) * mWeights[i];
                value += RandomOffSet(-0.5, 0.5);

                newTypConf[i] = Math.Clamp(value, minT[i], maxT[i]);
            }

            int tCountBelow5 = newTypConf.Count(t => t < 5);
            if (tCountBelow5 > 0)
            {
                var indexes = Enumerable.Range(0, newTypConf.Length).Where(i => newTypConf[i] < 5).ToList();
                int numToRaise = rnd.Next(1 , Math.Min(1, indexes.Count) + 1);

                for (int j  = 0; j < numToRaise; j++)
                {
                    int index = indexes[rnd.Next(indexes.Count)];
                    newTypConf[index] = 5 + rnd.NextDouble();
                    indexes.Remove(index);
                }


            }

            double tSum = newTypConf.Sum();
            if (tSum > 35)
            {
                double scale = 35 / mSum;
                for (int i = 0; i < newTypConf.Length; i++)
                    newTypConf[i + 1] *= scale;

            }

            conformationAttributes.Legs = newMovConf[0];
            conformationAttributes.Shoulders = newMovConf[1];
            conformationAttributes.Hindquarters = newMovConf[2];
            conformationAttributes.Pasterns = newMovConf[3];
            conformationAttributes.BackAndLoin = newMovConf[4];

            conformationAttributes.Head = newTypConf[0];
            conformationAttributes.Neck = newTypConf[1];
            conformationAttributes.ChestAndBarrel = newTypConf[2];
            conformationAttributes.BackAndTopline = newTypConf[3];
            conformationAttributes.OverallProportions = newTypConf[4];
        }
    }
}