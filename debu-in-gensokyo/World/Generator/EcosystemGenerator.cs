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
            int width = terrain.Width;
            int height = terrain.Height;
            int current_region_x = 0;
            foreach (IEcosystem ecosystem in ecosystems)
            {
                for (int i = 0; i < AttributeHelper.Get<EcosystemAttribute>(ecosystem.GetType()).MinWidth; i++)
                {
                    terrain.Regions[current_region_x].Ecosystem = ecosystem;
                    current_region_x++;
                    if (current_region_x >= terrain.Width)
                    {
                        return terrain;
                    }
                }
            }
            foreach (Region region in terrain.Regions)
            {
                if (region.Ecosystem == null)
                {
                    region.Ecosystem = ecosystems[0];
                }
            }
            return terrain;
        }
    }
}