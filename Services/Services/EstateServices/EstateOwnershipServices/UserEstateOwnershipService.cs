using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.RepositoryInterfaces.IEstateRepositories;
using Application.ServiceInterfaces.IEstateServices.IEstateOwnershipServices;
using Domain.Models;
using Domain.Models.EquineEstates;

namespace Application.Services.EstateServices.EstateOwnershipServices
{
    public class UserEstateOwnershipService : SharedEstateOwnershipService, IUserEstateOwnershipService
    {
        private readonly IEstateOwnershipRepository _estateOwnershipRepository;

        public UserEstateOwnershipService(IEstateOwnershipRepository estateOwnershipRepository)
            : base (estateOwnershipRepository) 
        { 
            _estateOwnershipRepository = estateOwnershipRepository;
        }



        public async Task LinkUserToEstateAsync (Guid userId, Guid estateId, bool isPrimaryOwner)
        {
            var ownership = new EquineEstatesOwner
            {
                UserId = userId,
                EquineEstateId = estateId,
                IsPrimaryOwner = true
            };

            await _estateOwnershipRepository.CreateOwnershipLinkAsync (ownership);
        }
    }
}

