using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IArtworkRelatedRepository.IHorseTypeSubmissionRepositories
{
    public interface IHorseTypeSubmissionRepository
    {
        Task CreateHorseTypeSubmissionAsync(HorseTypeSubmission horseTypeSubmission);

        Task<HorseTypeSubmission> GetHorseTypeSubmisionByIdAsync(int horseTypeSubmissionId);

        Task UpdateHorseTypeSubmissionAsync(HorseTypeSubmission horseTypeSubmission);

        Task DeleteHorseTypeSubmissionAsync(HorseTypeSubmission horseTypeSubmission);

        Task SaveChangesAsync();
    }
}
