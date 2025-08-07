using Application.RepositoryInterfaces.IHorseRepositories;
using Application.ServiceInterfaces.IHorseServices.IHorseOwnershipServices;
using Domain.Models.Horses;
using Domain.Models.Horses.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HorseServices.HorseOwnershipServices
{
    public class HorseOwnershipCrudService : IHorseOwnershipCrudService
    {
        private readonly IHorseOwnershipRepository _horseOwnershipRepository;

        public HorseOwnershipCrudService(IHorseOwnershipRepository horseOwnershipRepository)
        {
            _horseOwnershipRepository = horseOwnershipRepository;
        }

        public async Task CreateHorseOwnershipLinkAsync (Guid userId, Guid guidHorseId)
        {
            var newHorseOwnership = new HorseOwnership
            {
                UserId = userId,
                HorseGuidId = guidHorseId

            };

            await _horseOwnershipRepository.CreateHorseOwnershipLinkAsync (newHorseOwnership);
        }

        public async Task<HorseOwnership?> GetHorseOwnershipByIdAsync(Guid horseOwnershipId)
        {
            return await _horseOwnershipRepository.GetHorseOwnershipByIdAsync(horseOwnershipId);

        }

        public async Task UpdateHorseOwnershipAsync (HorseOwnership existingHorseOwnership, HorseOwnership udatedHorseOwnership)
        {
            existingHorseOwnership.UserId = udatedHorseOwnership.UserId;

            await _horseOwnershipRepository.UpdateHorseOwnershipAsync(existingHorseOwnership);
            await _horseOwnershipRepository.SaveChangesAsync();

        }

        public async Task DeleteHorseOwnershipAsync(HorseOwnership horseOwnership)
        {
            await _horseOwnershipRepository.DeleteHorseOwnershipAsync(horseOwnership);
        }
    }
}
