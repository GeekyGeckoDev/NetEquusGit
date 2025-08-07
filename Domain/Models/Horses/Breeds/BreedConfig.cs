using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Horses.Breeds
{
    public static class BreedConfig
    {
        public static readonly IReadOnlyDictionary<RarityTier, int> MaxFoalingsByRarity =
            new Dictionary<RarityTier, int>
            {
            { RarityTier.Normal, 11 },
            { RarityTier.Rare, 9 },
            { RarityTier.VeryRare, 7 },
            { RarityTier.Legendary, 5 }
            };
    }
}
