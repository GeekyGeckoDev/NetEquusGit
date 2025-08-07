using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales
{
    public class PrivateSale : HorseSaleBase
    {

        public Guid BuyerEquineEstateId { get; set; }

        public EquineEstate BuyerEquineEstate { get; set; }

        public int SalesPrice { get; set; }

        public bool Approved { get; set; }
    }
}
