using Application.RepositoryInterfaces.IEstateRepositories;
using Application.RepositoryInterfaces.IEstateRepositories;
using Application.ServiceInterfaces.IEstateServices.IEstateManagementServices;
using Application.ServiceInterfaces.IEstateServices.IEstateOwnershipServices;
using Application.Services.EstateServices.EstateManagementServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EstateServices.EstateOwnershipServices
{
    public class AdminEstateOwnershipService : SharedEstateOwnershipService, IAdminEstateOwnershipService
    {
        private readonly IEstateOwnershipRepository _estateOwnershipRepository;

        public AdminEstateOwnershipService(IEstateOwnershipRepository estateOwnershipRepository)
            : base(estateOwnershipRepository)
        { 
        }

        public async Task DeleteEstateOwnership(EquineEstatesOwner equineEstatesOwner)
        {
            await _estateOwnershipRepository.DeleteEstateOwnership(equineEstatesOwner);
        }

        public async Task UpdateEstateOwnership(EquineEstatesOwner equineEstatesOwner)
        {
            await _estateOwnershipRepository.UpdateEstateOwnership(equineEstatesOwner);
        }
    }
}


