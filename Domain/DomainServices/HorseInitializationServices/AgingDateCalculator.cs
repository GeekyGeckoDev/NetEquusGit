using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainServices.HorseInitializationServices
{
    public class AgingDateCalculator
    {
        public DateOnly CalculateAgeDate (Horse horse)
        {

            DateOnly birthdate = horse.BirthDate;

            // Ageing happens every 14 days
            int cycleLength = 14;

            // Count how many full cycles have passed since birth
            int daysAlive = DateOnly.FromDateTime(DateTime.Today).DayNumber - birthdate.DayNumber;
            int cyclesPassed = daysAlive / cycleLength;

            // Set the horse's current ageing date (the most recent one, not the next one)
            DateOnly ageingDate = birthdate.AddDays(cyclesPassed * cycleLength);

            return ageingDate;

        }
    }
}
