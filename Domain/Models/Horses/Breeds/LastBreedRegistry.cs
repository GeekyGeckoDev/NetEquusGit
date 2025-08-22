using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses.Breeds
{
    public class LastBreedRegistry

    {
        [Key] 
        public int Id { get; set; }

        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public int LastUsedNumber { get; set; }

    }
}
