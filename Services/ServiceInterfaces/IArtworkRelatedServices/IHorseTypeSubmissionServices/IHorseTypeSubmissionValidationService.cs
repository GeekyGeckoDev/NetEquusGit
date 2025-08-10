using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeSubmissionServices
{
    public interface IHorseTypeSubmissionValidationService
    {
        Task<HorseTypeSubmission> LoadAndValidateHorseTypeSubmission(int horseTypeSubmissionId);
    }
}
