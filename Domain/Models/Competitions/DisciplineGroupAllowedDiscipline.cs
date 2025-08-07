using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Competitions
{
    public class DisciplineGroupAllowedDiscipline
    {
 
            public int DisciplineGroupId { get; set; }

            public DisciplineGroup DisciplineGroup { get; set; }

            public Discipline Discipline { get; set; }
       
    }
}
