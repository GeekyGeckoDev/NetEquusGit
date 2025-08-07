using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.EquineEstates
{
    public class EquineEstateMergeRequest
    {

        [Key]
        public int EEMergeRequestId { get; set; }

      



        [ForeignKey(nameof(EquineEstateId))]
        public EquineEstate FromEquineEstate { get; set; }
        public Guid EquineEstateId { get; set;}



        [ForeignKey(nameof(ToEquineEstateId))]
        public EquineEstate ToEquineEstate { get; set; }
        public Guid ToEquineEstateId { get; set; }

        public string ProposedName { get; set; }

        public SubmissionStatus Status { get; set; }

        public DateTime RequestedAt { get; set; }

        public DateTime RespondedAt { get; set; }


    }
}
