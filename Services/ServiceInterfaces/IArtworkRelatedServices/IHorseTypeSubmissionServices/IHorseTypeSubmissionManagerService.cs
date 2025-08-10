using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeSubmissionServices
{
    public interface IHorseTypeSubmissionManagerService
    {
        Task<int> CreateCheckAndValidateHorseTypeSubmissionAsync(Guid userId, int breedId);

        Task<HorseTypeSubmission> GetAndValidateHorseTypeSubmissionAsync(int horseTypeSubmissionId, HorseTypeSubmission horseTypeSubmission);

        Task UpdateAndValidateHorseTypeSubmissionAsync(int horseTypeSubmissionId, HorseTypeSubmission existinghorseTypeSubmission, HorseTypeSubmission updatedHorseTypeSubmission);

        Task DeleteAndValidateHorseTypeSubmissionAsync(int horseTypeSubmissionId, HorseTypeSubmission horseTypeSubmission);
    }
}
