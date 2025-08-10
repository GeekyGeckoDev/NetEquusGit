using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IUserRepositories.IHorseArtistRepositories
{
    public interface IGetHorseArtistRepositories
    {
        Task<HorseArtist?> GetHorseArtistByUser(Guid userId);
    }
}
