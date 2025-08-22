using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository
{
    public interface IFoalingCrudRepository
    {
        Task CreateFoalingAsync (Foaling foaling);

        Task<Foaling?> GetFoalingByIdAsync(int foalingId);

        Task UpdateFoalingAsync (Foaling foaling);

        Task DeleteFoalingAsync (Foaling foalingId);

        Task SaveChangesAsync();
    }
}
