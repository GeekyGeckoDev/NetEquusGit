using Application.RepositoryInterfaces.IEstateRepositories;
using Application.RepositoryInterfaces.IEstateRepositories;
using Application.ServiceInterfaces.IEstateServices.IEstateManagementServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EstateServices.EstateOwnershipServices
{
    public abstract class SharedEstateOwnershipService
    {
        private readonly IEstateOwnershipRepository _estateOwnershipRepository;

        protected SharedEstateOwnershipService(IEstateOwnershipRepository estateOwnershipRepository)
        {
            _estateOwnershipRepository = estateOwnershipRepository;
        }

        public async Task<EquineEstatesOwner?> GetEstsateOwnershipByIdAsync(Guid estateOwnershipId)
        {
            return await _estateOwnershipRepository.GetEstsateOwnershipByIdAsync(estateOwnershipId);
        }

    }
}


