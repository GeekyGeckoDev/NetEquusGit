using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales
{
    [NotMapped]
    public abstract class SaleEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public Vendor Organizer { get; set; }
        public ICollection<Horse> HorsesOffered { get; set; }

        public abstract bool CanSell(Horse horse, Vendor vendor);
    }


}
