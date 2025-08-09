using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IHorseRepositories;
using Application.ServiceInterfaces.IHorseServices.IHorseCrudServices;
using Application.ServiceInterfaces.IUserServices.IUserManagementServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HorseServices.HorseCrudServices
{
    public abstract class SharedHorseCrudService : ISharedHorseCrudService
    {

        private readonly IHorseCrudRepository _horseCrudRepository;

        protected SharedHorseCrudService(IHorseCrudRepository horseCrudRepository)
        {
            _horseCrudRepository = horseCrudRepository;
        }
        public abstract Task UpdateHorseAsync(Horse existingHorse, Horse updatedHorse);

        public virtual async Task<Horse> GetHorseByIdAsync(Guid horseGuidId)
        {
            return await _horseCrudRepository.GetHorseByIdAsync(horseGuidId);
        }
       
    }
}


