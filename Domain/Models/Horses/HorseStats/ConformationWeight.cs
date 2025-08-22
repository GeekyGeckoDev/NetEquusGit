using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses.HorseStats
{
    public class ConformationWeight
    {
        public double LegsWeight { get; set; } = 1.0;
        public double ShouldersWeight { get; set; } = 1.0;
        public double HindquartersWeight { get; set; } = 1.0;
        public double PasternsWeight { get; set; } = 1.0;
        public double BackAndLoinWeight { get; set; } = 1.0;

        // Type related
        public double HeadWeight { get; set; } = 1.0;
        public double NeckWeight { get; set; } = 1.0;
        public double ChestAndBarrelWeight { get; set; } = 1.0;
        public double BackAndToplineWeight { get; set; } = 1.0;
        public double OverallProportionsWeight { get; set; } = 1.0;
    }
}
