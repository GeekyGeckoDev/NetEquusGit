using Application.RepositoryInterfaces.IEstateRepositories;
using Application.RepositoryInterfaces.IEstateRepositories;
using Application.ServiceInterfaces.IEstateServices.IEstateManagementServices;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}


