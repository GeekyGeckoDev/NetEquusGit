using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Enums
{
    public enum GroundType
    {
        // Common in Dressage, Showjumping, Western Pleasure, Reining
        Sand,           // All-round arena footing

        EquiFleece,     // Specialized arena footing (all disciplines)

        Fiber,          // Often mixed with sand, used in Dressage, Showjumping

        WoodChips,      // Sometimes in western arenas or cross country trails

        Rubber,         // Common additive in arenas (Dressage, Showjumping)

        Clay,           // Dressage, Showjumping, Western arenas

        Grass,          // Dressage, Showjumping, Cross Country, Western

        // Synthetic footing, used mainly in Dressage and Showjumping arenas
        Synthetic,

        // Dressage and Showjumping arenas, sometimes other flat disciplines
        Cinder,

        ClaySand,       // Mixed clay and sand, Dressage and Showjumping

        // Cross Country and natural terrain disciplines
        NaturalTerrain, // Cross Country trails

        Gravel,         // Cross Country paths, some trail riding

        Mud,            // Cross Country (weather-dependent)

        HardPack,       // Cross Country, trail riding firm paths

        // Western disciplines
        Loam,           // Western Pleasure, Reining arenas

        Caliche,        // Western Pleasure and Reining (hard packed soil)

        ArenaDirt,      // Western arenas (general dirt)

        Sawdust         // Sometimes used in Western arenas, adds cushion
    }
}
