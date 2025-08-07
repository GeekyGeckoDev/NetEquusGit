using Application.Services.UserServices.UserValidationServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.UserManagementServices
{
    public class UserManagerService
    {
        private readonly UserValidationService _userValidationService;
        private readonly SharedUserCrudService _userCrudService;


        public UserManagerService(UserValidationService userValidationService, SharedUserCrudService userCrudService)
        {
            _userValidationService = userValidationService;
            _userCrudService = userCrudService;
          
        }

        public async Task UpdateAndValidateUserAsync(Guid userId, User updatedUserData)
        {
            var existingUser = await _userValidationService.LoadAndValidateUserAsync(userId);

            // Pass both existing user entity AND the updated data to CRUD service for controlled field updates
            await _userCrudService.UpdateUserAsync(existingUser, updatedUserData);
        }
    }
}
