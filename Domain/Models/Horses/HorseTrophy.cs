using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses
{
    public abstract class HorseTrophy : TrophyBase
    {

        public Guid HorseId { get; set; }
    }

    public class BreedingHorseTrophy : HorseTrophy
    {
        public int NumberOfFoals { get; set; }
    }
}
