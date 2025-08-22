using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Enums;
using Domain.Models;

namespace Domain.DomainServices.RandomGenerators
{
    public class RandomGenderService
    {
        public Horse Horse;

        public int Gender
        {
            get => (int)Horse.HorseGender;
            set => Horse.HorseGender = (HorseGender)value;
        }

        public HorseGender RandomGender()
        {
            Random rnd = new Random();
            int genderValue = rnd.Next(0, 2); // 0 or 1
            return (HorseGender)genderValue;
        }

    }
}