using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Sales
{
    public class AuctionSale : HorseSaleBase
    {

        public int StartBid { get; set; }

        public int? BuyNowPrice { get; set; }

        public DateTime AuctionStartTime { get; set; }

        public DateTime AuctionEndTime  { get; set; }

        public ICollection<AuctionBid> Bids { get; set; }

        public int? WinningBidId { get; set; }

        [ForeignKey("WinningBidId")]
        public AuctionBid WinningBid { get; set; }
    }
}
