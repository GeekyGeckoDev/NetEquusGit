using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.RepositoryInterfaces
{

    public interface IUserCrudRepository
    {
        Task CreateUserAsync(User user);

        Task <User?> GetUserByIdAsync (Guid id);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(User user);

        Task SaveChangesAsync();
    }
}