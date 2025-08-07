using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Shared
{
    public class SeasonWeatherAllowed
    {
        public int SeasonsId { get; set; }


        public Season Season { get; set; }

        public Weather WeatherId { get; set; }
    }
}
