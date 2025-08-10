using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeSubmissionServices
{
    public interface IHorseTypeSubmissionCrudService
    {
        Task<int> CreateHorseTypeSubmissionAsync(HorseTypeSubmission horseTypeSubmission);

        Task<HorseTypeSubmission?> GetHorseTypeSubmissionByIdAsync(int horseTypeSubmissionId);

        Task UpdateHorseTypeSubmisionAsync(HorseTypeSubmission existinghorseTypeSubmission, HorseTypeSubmission updatedHorseTypeSubmission);

        Task DeleteHorseTypeSubmissionAsync(HorseTypeSubmission horseTypeSubmission);

    }
}
