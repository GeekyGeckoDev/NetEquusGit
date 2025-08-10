using Application.RepositoryInterfaces.IUserRepositories.IHorseArtistRepositories;
using Application.ServiceInterfaces.IUserRelatedServices.IHorseArtistService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserRelatedServices.HorseArtistServices
{
    public class HorseArtistValidationService : IHorseArtistValidationService
    {
        public readonly IGetHorseArtistRepositories _getHorseArtistRepositories;

        public HorseArtistValidationService(IGetHorseArtistRepositories getHorseArtistRepositories)
        {
            _getHorseArtistRepositories = getHorseArtistRepositories;
        }

        public async Task<bool> ValidateIsHorseArtist (Guid userId)
        {
            var horseArtist = await _getHorseArtistRepositories.GetHorseArtistByUser (userId);

            return horseArtist != null;
        }
    }
}
