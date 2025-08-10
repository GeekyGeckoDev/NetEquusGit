using Application.RepositoryInterfaces;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using Application.ServiceInterfaces.IUserRelatedServices.IUserServices.IUserValidationServices;

namespace Application.Services.UserRelatedServices.UserServices.UserValidationServices
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
            if (user == null) throw new ValidationException ("User not found");
            return user;
        }

        public async Task ValidateUserIsHorseArtist (Guid userId)
        {

        }
    }
}

