using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses.HorseStats
{
    public class PerformanceWeight
    {
        public double GaitsWeight { get; set; } = 1.0;
        public double JumpingWeight { get; set; } = 1.0;
        public double SpeedWeight { get; set; } = 1.0;
        public double AgilityWeight { get; set; } = 1.0;
        public double EnduranceWeight { get; set; } = 1.0;
        public double StrideWeight { get; set; } = 1.0;
        public double TrainabilityWeight { get; set; } = 1.0;
    }
}
