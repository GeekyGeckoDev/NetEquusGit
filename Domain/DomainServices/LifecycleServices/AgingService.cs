using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.LifecycleServices
{
    public class AgingService
    {
        public double UpdateAge (Horse horse)
        {

            int cycleLength = 28;
            DateOnly birthdate = horse.BirthDate;
            int daysAlive = DateOnly.FromDateTime(DateTime.Now).DayNumber - birthdate.DayNumber;

            double Age = daysAlive / cycleLength;

            return Age;


        }
    }
}
