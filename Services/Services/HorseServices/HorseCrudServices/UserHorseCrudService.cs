using Application.RepositoryInterfaces.IHorseRepositories;
using Application.ServiceInterfaces.IHorseServices.UHorseCrudServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HorseServices.HorseCrudServices
{
    public class UserHorseCrudService : SharedHorseCrudService, IUserHorseCrudService
    {
        private readonly IHorseCrudRepository _horseCrudRepository;

        public UserHorseCrudService(IHorseCrudRepository horseCrudRepository)
            : base(horseCrudRepository)
        {
            _horseCrudRepository = horseCrudRepository;
        }

        public override async Task UpdateHorseAsync(Horse existingHorse, Horse updatedHorse)
        {
            //The shit that user can edit on a horse
            existingHorse.HorseName = updatedHorse.HorseName;

            _horseCrudRepository.UpdateHorseAsync(existingHorse);
            await _horseCrudRepository.SaveChangesAsync();
        }
    }
}


