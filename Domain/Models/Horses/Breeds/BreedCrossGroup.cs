using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses.Breeds
{
    public class BreedCrossGroup
    {
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        public int CrossGroupId { get; set; }
        public virtual CrossGroup CrossGroup { get; set; }

    }
}
