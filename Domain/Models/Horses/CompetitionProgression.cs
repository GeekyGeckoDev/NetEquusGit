using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses
{
    public class CompetitionProgression
    {


        [ForeignKey(nameof(Horse))]
    
        public Guid GuidHorseId { get; set; }

        public Horse Horse { get; set; }
        public int CompetitionLevel { get; set; }
        public double CompetitionPoints { get; set; }
        public DateTime? DateLastCompetition { get; set; }
        public int TotalCompetitions { get; set; }
        // You can add more fields if needed, like progress milestones or bonuses
    }
}
