using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IHorseRepositories;
using Application.ServiceInterfaces.IHorseServices.UHorseCrudServices;
using Application.ServiceInterfaces.IUserServices.IUserManagementServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HorseServices.HorseCrudServices
{
    public class AdminHorseCrudService : SharedHorseCrudService, IAdminHorseCrudService
    {
        private readonly IHorseCrudRepository _horseCrudRepository;

        public AdminHorseCrudService(IHorseCrudRepository horseCrudRepository)
            : base(horseCrudRepository)
        {
            _horseCrudRepository = horseCrudRepository;
        }

        public async Task<Guid> CreateHorseAsync (Horse horse)
        {
            await _horseCrudRepository.CreateHorseAsync (horse);
            await _horseCrudRepository.SaveChangesAsync();

            return horse.GuidHorseId;
        }

        public async Task DeleteHorseAsync(Horse horse)
        {
            await _horseCrudRepository.DeleteHorseAsync(horse);
        }

        public override async Task UpdateHorseAsync(Horse existingHorse, Horse updatedHorse)
        {
            //The shit that admin can edit on a horse
            existingHorse.HorseName = updatedHorse.HorseName;

            _horseCrudRepository.UpdateHorseAsync(existingHorse);
            await _horseCrudRepository.SaveChangesAsync ();
        }
    }
}
