using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface IHorseTypeCrudRepository
    {
        Task CreateHorseTypeAsync(HorseType horseType);

        Task<HorseType> GetHorseTypeByIdAsync(int horseTypeId);

        Task UpdateHorseTypeAsync(HorseType horseType);

        Task DeleteHorseTypeAsync(HorseType horseType);

        Task SaveChangesAsync();
    }
}
