using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IEstateRepositories;
using Application.ServiceInterfaces.IEstateServices.IEstateManagementServices;
using Application.ServiceInterfaces.IUserServices.IUserManagementServices;
using Application.Services.UserServices.UserManagementServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EstateServices.EstateManagementServices
{
    public abstract class SharedEstateCrudService : ISharedEstateCrudService
    {

        private readonly IEstateCrudRepository _estateCrudRepository;

        protected SharedEstateCrudService (IEstateCrudRepository estateCrudRepository)
        {
            _estateCrudRepository = estateCrudRepository;
        }



        public abstract Task UpdateEstateAsync(EquineEstate existingEstate, EquineEstate updatedEstate);

        public virtual async Task<EquineEstate> GetEstateByIdAsync (Guid equineEstateId)
        {
            return await _estateCrudRepository.GetEstateByIdAsync(equineEstateId);
        }

        public async Task<EquineEstate> GetEstateByUserIdAsync (Guid userId)
        {
            return await _estateCrudRepository.GetEstateByUserIdAsync(userId);
        }
    }
}
