using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses.HorseStats
{
    public class PerformanceAttributes
    {
        public int PerfId { get; set; }

        public double Gaits { get; set; }

        public double Jumping { get; set; }

        public double Speed { get; set; }

        public double Agility { get; set; }

        public double Endurance { get; set; }

        public double Stride { get; set; }

        public double Rideability { get; set; }

        public string Temperament { get; set; }
    }
}
