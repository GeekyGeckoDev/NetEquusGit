using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository;
using Application.ServiceInterfaces.IHorseServices.IHorseCrudServices;
using Domain.Models;

namespace Application.Services.HorseRelatedServices.HorseServices.HorseCrudServices
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
            var newHorse = new Horse
            {
                GuidHorseId = Guid.NewGuid(),
                HorseRegistryId = "blob" //Make method for generating Id's),



            };
            await _horseCrudRepository.CreateHorseAsync (horse);
            await _horseCrudRepository.SaveChangesAsync();

            return newHorse.GuidHorseId;
        }

        public async Task DeleteHorseAsync(Horse horse)
        {
            await _horseCrudRepository.DeleteHorseAsync(horse);
        }

        public override async Task UpdateHorseAsync(Horse existingHorse, Horse updatedHorse)
        {
            //The shit that admin can edit on a horse
            existingHorse.HorseName = updatedHorse.HorseName;

            await _horseCrudRepository.UpdateHorseAsync(existingHorse);
            await _horseCrudRepository.SaveChangesAsync ();
        }
    }
}
