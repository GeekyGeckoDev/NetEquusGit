using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IUserRepositories
{
    public interface IValidateUserOwnershipRepository
    {
        Task<bool> UserOwnsHorseAsync(Guid userId, Guid horseId);

        Task<bool> UserOwnsEstateAsync(Guid userId, Guid equineEstateId);

    }
}
