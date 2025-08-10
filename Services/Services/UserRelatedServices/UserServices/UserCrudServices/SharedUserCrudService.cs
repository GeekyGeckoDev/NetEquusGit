using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Application.RepositoryInterfaces;
using Application.ServiceInterfaces.IUserRelatedServices.IUserServices.IUserCrudServices;

namespace Application.Services.UserRelatedServices.UserServices.UserCrudServices
{
    public abstract class SharedUserCrudService : ISharedUserCrudService
    {
        private readonly IUserCrudRepository _userCrudRepository;

        protected SharedUserCrudService(IUserCrudRepository userCrudRepository)
        {
            _userCrudRepository = userCrudRepository;
        }

         public abstract Task UpdateUserAsync(User existingUser, User updatedUser);


        public virtual async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await _userCrudRepository.GetUserByIdAsync(userId);
        }

    }
}
