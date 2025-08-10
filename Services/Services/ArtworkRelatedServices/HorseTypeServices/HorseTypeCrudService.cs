using Application.RepositoryInterfaces;
using Application.ServiceInterfaces.IArtworkRelatedServices.IHorseTypeServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ArtworkRelatedServices.HorseTypeServices
{
    public class HorseTypeCrudService : IHorseTypeCrudService
    {
        private readonly IHorseTypeCrudRepository _horseTypeCrudRepository;

        public HorseTypeCrudService(IHorseTypeCrudRepository horseTypeCrudRepository)
        {
            _horseTypeCrudRepository = horseTypeCrudRepository;
        }

        public async Task CreateHorseTypeAsync (HorseType horseType)
        {
            await _horseTypeCrudRepository.CreateHorseTypeAsync(horseType);
            await _horseTypeCrudRepository.SaveChangesAsync();
        }

        public async Task<HorseType> GetHorseTypeByIdAsync (int horseTypeId)
        {
            return await _horseTypeCrudRepository.GetHorseTypeByIdAsync(horseTypeId);
        }

        public async Task UpdateHorseTypeAsync (HorseType existingHorseType, HorseType updatedHorseType)
        {
            existingHorseType.Breed = updatedHorseType.Breed;

            await _horseTypeCrudRepository.UpdateHorseTypeAsync(existingHorseType);
            await _horseTypeCrudRepository.SaveChangesAsync();
        }

        public async Task DeleteHorseTypeAsync(HorseType horseType)
        {
            await _horseTypeCrudRepository.DeleteHorseTypeAsync(horseType);
        }
    }
}
