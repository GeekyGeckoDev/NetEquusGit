using Application.RepositoryInterfaces;
using Application.ServiceInterfaces.IUserRelatedServices.IUserServices.IUserCrudServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserRelatedServices.UserServices.UserCrudServices
{
    public class UserUserCrudService : SharedUserCrudService, IUserUserCrudService
    {
        private readonly IUserCrudRepository _userCrudRepository;

        public UserUserCrudService(IUserCrudRepository userCrudRepository)
             : base(userCrudRepository)
        {
        }

        public override async Task UpdateUserAsync(User existingUser, User updatedUser)
        { 
            // User updates only allowed subset of fields
        existingUser.Name = updatedUser.Name;
        existingUser.UserEmail = updatedUser.UserEmail;

        // No call to Update() needed if tracked by EF
        await _userCrudRepository.SaveChangesAsync();
    }
    }
}
