using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IEstateRepositories
{
    public interface IEstateOwnershipRepository
    {
        Task CreateEstateOwnershipLinkAsync(EquineEstatesOwner ownershipLink);

        Task<EquineEstatesOwner?> GetEstsateOwnershipByIdAsync(Guid estateOwnershipId);

        Task UpdateEstateOwnership(EquineEstatesOwner equineEstatesOwner);

        Task DeleteEstateOwnership(EquineEstatesOwner equineEstatesOwner);


    }
}
