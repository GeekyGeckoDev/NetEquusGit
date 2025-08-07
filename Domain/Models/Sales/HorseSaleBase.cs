using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales
{
    public abstract class HorseSaleBase
    {
        [Key]
        public int HorseSaleId { get; set; }

        [Required, ForeignKey("Horse")]
        public Guid HorseId { get; set; }

        public Horse Horse { get; set; }

        [ForeignKey(nameof(EquineEstateId))]

        public Guid EquineEstateId { get; set; }

        public EquineEstate SellerEquineEstate { get; set; }

        [Required, ForeignKey("Vendor")]
        public int VendorId { get; set; }

        public Vendor Vendor { get; set; }

        public DateTime DateOfSale { get; set; }

        public int? SaleEventId { get; set; } // Optional if sale is part of an event

        public SaleEvent SaleEvent { get; set; }
    }
}
