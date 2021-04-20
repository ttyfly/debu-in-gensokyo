using System.Collections.Generic;
using DebuInGensokyo.World.Ecosystem;
using DebuInGensokyo.Utility;

namespace DebuInGensokyo.World.Generator
{
    class EcosystemGenerator : IGenerator
    {
        List<IEcosystem> ecosystems;
        public EcosystemGenerator(List<IEcosystem> ecosystems)
        {
            this.ecosystems = ecosystems;
        }
        public Terrain apply(Terrain terrain)
        {
            uint width = terrain.Width;
            uint height = terrain.Height;
            int current_area_x = 0;
            foreach (IEcosystem ecosystem in ecosystems)
            {
                for (int i = 0; i < AttributeHelper.Get<EcosystemAttribute>(ecosystem.GetType()).MinWidth; i++)
                {
                    terrain.Areas[current_area_x].Ecosystem = ecosystem;
                    current_area_x++;
                    if (current_area_x >= terrain.Width)
                    {
                        return terrain;
                    }
                }
            }
            return terrain;
        }
    }
}