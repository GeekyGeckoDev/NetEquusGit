using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IEstateRepositories;
using Application.ServiceInterfaces.IEstateServices.IEstateManagementServices;
using Application.ServiceInterfaces.IEstateServices.IEstateOwnershipServices;
using Application.ServiceInterfaces.IUserServices.IUserManagementServices;
using Application.Services.EstateServices.EstateManagementServices;
using Application.Services.EstateServices.EstateOwnershipServices;
using Domain.Models;
using Application.ServiceInterfaces.IUserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ServiceInterfaces.IUserServices.IUserValidationServices;

namespace Application.Services.UserServices.UserValidationServices
{
    public class UserValidationService : IUserValidationService
    {

        private readonly IUserCrudRepository _userCrudRepository;

            public UserValidationService(IUserCrudRepository userCrudRepository)
        {
            _userCrudRepository = userCrudRepository;
        }


        public async Task<User> LoadAndValidateUserAsync(Guid userId)
        {
            var user = await _userCrudRepository.GetUserByIdAsync(userId);
            if (user == null) throw new Exception("User not found");
            return user;
        }
    }
}

