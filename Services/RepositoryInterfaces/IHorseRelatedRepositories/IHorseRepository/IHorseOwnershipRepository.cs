using Domain.Models.Horses;
using Domain.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository
{
    public interface IHorseOwnershipRepository
    {
        Task CreateHorseOwnershipLinkAsync(HorseOwnership ownershipLink);

        Task<HorseOwnership?> GetHorseOwnershipByIdAsync(Guid horseOwnershipId);

        Task UpdateHorseOwnershipAsync(HorseOwnership horseOwnership);

        Task DeleteHorseOwnershipAsync(HorseOwnership horseOwnership);

        Task SaveChangesAsync();

    }
}
