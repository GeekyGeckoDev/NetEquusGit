using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IEstateRepositories
{
    public interface IEstateCrudRepository
    {
        Task CreateEstateAsync(EquineEstate newEstate);

        Task<EquineEstate?> GetEstateByIdAsync(Guid id);

        Task<EquineEstate> GetEstateByUserIdAsync(Guid userId);

        Task UpdateEstateAsync(EquineEstate equineEstate);

        Task DeleteEstateAsync(EquineEstate equineEstate);

        Task SaveChangesAsync();
    }
}
