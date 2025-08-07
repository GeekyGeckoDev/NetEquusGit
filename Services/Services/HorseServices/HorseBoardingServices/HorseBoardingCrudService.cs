using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IEstateRepositories;
using Application.RepositoryInterfaces.IHorseRepositories;
using Application.ServiceInterfaces.IHorseServices.IHorseBoardingService;
using Application.Services.EstateServices.EstateOwnershipServices;
using Domain.Models;
using Domain.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HorseServices.HorseBoardingServices
{
    public class HorseBoardingCrudService : IHorseBoardingCrudService
    {
        private readonly IHorseBoardingRepository _horseBoardingRepository;

        public HorseBoardingCrudService(IHorseBoardingRepository horseBoardingRepository)
        {
            _horseBoardingRepository = horseBoardingRepository;
        }

        public async Task CreateHorseBoardingLinkAsync(DateTime StartDate, Guid userId, Guid estateId, Guid guidHorseId, bool IsPermanentResidence)
        {
            var newHorseBoarding = new HorseBoarding
            {
                StartDate = DateOnly.FromDateTime(DateTime.UtcNow),
                BoarderId = userId,

                BoardingEstateId = estateId,

                IsPermanentResidence = true
            };
            
            await _horseBoardingRepository.CreateHorseBoardingLinkAsync(newHorseBoarding);
        }
        

        public async Task<HorseBoarding?> GetHorseBoardingByIdAsync (Guid horseBoardingId)
        {
            return await _horseBoardingRepository.GetHorseBoardingByIdAsync(horseBoardingId);
        }

        public async Task UpdateHorseBoardingAsync(HorseBoarding existinghorseBoarding, HorseBoarding updatedHorseBoarding)
        {
            existinghorseBoarding.EndDate = updatedHorseBoarding.EndDate;
            existinghorseBoarding.IsPermanentResidence = updatedHorseBoarding.IsPermanentResidence;

            await _horseBoardingRepository.UpdateHorseBoardingAsync(existinghorseBoarding);
            await _horseBoardingRepository.SaveChangesAsync();
        }

        public async Task DeleteHorseBoardingAsync (HorseBoarding horseBoarding)
        {
            await _horseBoardingRepository.DeleteHorseBoardingAsync(horseBoarding);
        }
    }
}

