using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IEstateRepositories;
using Application.ServiceInterfaces.IEstateServices.IEstateManagementServices;
using Application.Services.UserServices.UserManagementServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EstateServices.EstateManagementServices
{
    public class AdminEstateCrudService : SharedEstateCrudService, IAdminEstateCrudService
    {
        private readonly IEstateCrudRepository _estateCrudRepository;


        public AdminEstateCrudService(IEstateCrudRepository estateCrudRepository)
                : base(estateCrudRepository)
        {
        }

    
        public async Task DeleteEstateAsync(EquineEstate equineEstate)
        {
            await _estateCrudRepository.DeleteEstateAsync(equineEstate);
        }

        public override async Task UpdateEstateAsync (EquineEstate existingEstate, EquineEstate updatedEstate)
        {
            //
            //    existingUser.UserEmail = updatedUser.UserEmail;
            //    existingUser.Password = updatedUser.Password;
            //    existingUser.UserName = updatedUser.UserName;
            //    existingUser.Age = updatedUser.Age;
            // Shit that admin can update about the estate

            await _estateCrudRepository.SaveChangesAsync();
        }
        
    }
}


