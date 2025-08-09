using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IHorseServices.IHorseValidationServices
{
    public interface IHorseValidationService
    {
        Task<Horse> LoadAndValidateHorseAsync(Guid horseGuidId);

        void ValidateHorseData(Horse horse, bool isFoaling);
    }
}
