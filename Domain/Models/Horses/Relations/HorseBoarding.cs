using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses.Relations
{
    public class HorseBoarding
    {
        [Key]
        public Guid HorseBoardingId { get; set; }

        [Required]
        public Guid GuidHorseId { get; set; }
        public virtual Horse Horse { get; set; }

        [Required]
        public Guid BoardingEstateId { get; set; }
        public virtual EquineEstate EquineEstate { get; set; }

        [Required]
        public Guid BoarderId { get; set; }
        public virtual User Boarder { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public bool IsPermanentResidence { get; set; }
    }
}
