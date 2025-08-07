using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses.HorseStats
{
    public class ConformationAttributes
    {
        public int ConfId { get; set; }

        // Movement related
        public double Legs { get; set; }
        public double Shoulders { get; set; }
        public double Hindquarters { get; set; }
        public double Pasterns { get; set; }
        public double BackAndLoin { get; set; }

        // Type related
        public double Head { get; set; }
        public double Neck { get; set; }
        public double ChestAndBarrel { get; set; }
        public double BackAndTopline { get; set; }
        public double OverallProportions { get; set; }

        // Computed properties, NOT stored in DB
        [NotMapped]
        public double MovementScore => (Legs + Shoulders + Hindquarters + Pasterns + BackAndLoin) / 5;

        [NotMapped]
        public double TypeScore => (Head + Neck + ChestAndBarrel + BackAndTopline + OverallProportions) / 5;
    }
}
