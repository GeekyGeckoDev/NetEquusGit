using Application.RepositoryInterfaces.IHorseRelatedRepositories.IHorseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Services.HorseRelatedServices.FoalingServices
{
    public class FoalingCrudService
    {

        private readonly IFoalingCrudRepository _foalingCrudRepository;

        public FoalingCrudService(IFoalingCrudRepository foalingCrudRepository)
        {
            _foalingCrudRepository = foalingCrudRepository;
        }
        public async Task CreateFoalingAsync (Foaling faoling)
        {
            await _foalingCrudRepository.CreateFoalingAsync(faoling);
            await _foalingCrudRepository.SaveChangesAsync();
        }

        public async Task <Foaling?> GetFoalingByIdAsync (int foalingId)
        {
            return await _foalingCrudRepository.GetFoalingByIdAsync(foalingId);
        }

        public async Task UpdateFoalingAsync (Foaling foaling)
        {
            await _foalingCrudRepository.UpdateFoalingAsync(foaling);
            await _foalingCrudRepository.SaveChangesAsync();
        }

        public async Task DeleteFoalingAsync(Foaling foaling)
        {
            await _foalingCrudRepository.DeleteFoalingAsync(foaling);
            await _foalingCrudRepository.SaveChangesAsync();
        }
    }
}
