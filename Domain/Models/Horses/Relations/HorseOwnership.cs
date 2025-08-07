using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses
{
    public class HorseOwnership
    {

        [Key]
        public Guid HorseOwnershipId {  get; set; }

        [ForeignKey ("Horse")]
        public Guid HorseGuidId { get; set; }
        public virtual Horse Horse { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User user { get; set; }
    }
}
