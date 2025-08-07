﻿using Domain.Models.Horses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces.IHorseServices.IHorseOwnershipServices
{
    public interface IHorseOwnershipCrudService
    {

        Task<HorseOwnership?> GetHorseOwnershipByIdAsync(Guid horseOwnershipId);


    }
}
