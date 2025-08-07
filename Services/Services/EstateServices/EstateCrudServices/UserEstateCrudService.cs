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
    public class UserEstateCrudService : SharedEstateCrudService, IUserEstateCrudService
    {
        private readonly IEstateCrudRepository _estateCrudRepository;

        public UserEstateCrudService(IEstateCrudRepository estateCrudRepository)
            : base(estateCrudRepository)
        {
            _estateCrudRepository = estateCrudRepository;   
        }

        public override async Task UpdateEstateAsync(EquineEstate existingEstate, EquineEstate updatedEstate)
        {
            //
            //    existingUser.UserEmail = updatedUser.UserEmail;
            //    existingUser.Password = updatedUser.Password;
            //    existingUser.UserName = updatedUser.UserName;
            //    existingUser.Age = updatedUser.Age;
            // Shit that user can update about the estate

            await _estateCrudRepository.SaveChangesAsync();
        }

        
        public async Task<Guid> CreateEstateAsync(EquineEstate newEstate)
        {
            await _estateCrudRepository.CreateEstateAsync(newEstate);
            return newEstate.EquineEstateId;
        }
    } 
}