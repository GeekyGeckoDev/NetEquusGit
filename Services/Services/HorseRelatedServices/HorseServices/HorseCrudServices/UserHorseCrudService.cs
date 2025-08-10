﻿using Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository;
using Application.ServiceInterfaces.IHorseServices.IHorseCrudServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HorseRelatedServices.HorseServices.HorseCrudServices
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

            await _horseCrudRepository.UpdateHorseAsync(existingHorse);
            await _horseCrudRepository.SaveChangesAsync();
        }
    }
}


