using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IEstateRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EstateServices.EstateValidationServices
{
    public class EstateValidationService
    {
        private readonly IEstateCrudRepository _estateCrudRepository;

        public EstateValidationService(IEstateCrudRepository estateCrudRepository)
        {
            _estateCrudRepository = estateCrudRepository;
        }

        public virtual async Task<EquineEstate> LoadAndValidateEstateAsync(Guid equineEstateId)
        {
            var equineEstate = await _estateCrudRepository.GetEstateByIdAsync(equineEstateId);
            if (equineEstate == null) throw new Exception("Estate not found");
            return equineEstate;
        }
    }
}
