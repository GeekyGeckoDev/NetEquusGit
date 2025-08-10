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
    public class AdminUserCrudService : SharedUserCrudService, IAdminUserCrudService
    {
        private readonly IUserCrudRepository _userCrudRepository;

        public AdminUserCrudService(IUserCrudRepository userCrudRepository)
             : base(userCrudRepository)
        {
            _userCrudRepository = userCrudRepository;
        }
        public async Task CreateUserAsync(User user)
        {
            user.CreationDate = DateTime.UtcNow;
            await _userCrudRepository.CreateUserAsync(user);
            await _userCrudRepository.SaveChangesAsync();
        }




        public async Task DeleteUserAsync(User user)
        {
            await _userCrudRepository.DeleteUserAsync(user);
        }

        public override async Task UpdateUserAsync(User existingUser, User updatedUser)
        {
            existingUser.Name = updatedUser.Name;
            existingUser.UserEmail = updatedUser.UserEmail;
            existingUser.Password = updatedUser.Password;
            existingUser.UserName = updatedUser.UserName;
            existingUser.Age = updatedUser.Age;

            _userCrudRepository.UpdateUserAsync(existingUser);
            await _userCrudRepository.SaveChangesAsync();
        }
    }
}