﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IUserRelatedServices.IUserServices.IUserCrudServices
{
    public interface ISharedUserCrudService
    {
        Task UpdateUserAsync(User existingUser, User updatedUser);

        Task<User?> GetUserByIdAsync(Guid userId);
    }
}
