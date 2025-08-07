using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public abstract class PlayerTrophy : TrophyBase
    {

        public Guid UserId { get; set; }
    }

    public  class BreedingTrophy : PlayerTrophy
    {
        public int FoalsBred { get; set; }
    }
}
