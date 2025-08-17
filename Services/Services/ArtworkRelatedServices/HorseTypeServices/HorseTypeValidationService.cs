using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;
using Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeServices;
using Domain.Models;

namespace Application.Services.ArtworkRelatedServices.HorseTypeServices
{
    public class HorseTypeValidationService : IHorseTypeValidationService
    {
        private readonly IHorseTypeCrudRepository _horseTypeCrudRepository;


        public HorseTypeValidationService(IHorseTypeCrudRepository horseTypeCrudRepository)
        {
            _horseTypeCrudRepository = horseTypeCrudRepository;
        }

        public async Task<HorseType> ValidateAndLoadHorseTypeAsync(int horseTypeId)
        {
            var horseType = await _horseTypeCrudRepository.GetHorseTypeByIdAsync(horseTypeId);
            if (horseType == null) throw new ValidationException("HorseType not found");

            return horseType;

        }
    }
}