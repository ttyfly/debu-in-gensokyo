using DebuInGensokyo.Utility;
using DebuInGensokyo.World.Ecosystem;

namespace DebuInGensokyo.World.Generator
{
    class SurfaceGenerator : IGenerator
    {
        public SurfaceGenerator() {}
        public Terrain apply(Terrain terrain)
        {
            foreach (Area area in terrain.Areas)
            {
                uint altitude = AttributeHelper.Get<EcosystemAttribute>(area.Ecosystem.GetType()).Altitude;
                for (int i = 0; i < altitude; i++)
                {
                    area.Chunks[i].FillWith(1);
                }
                Chunk surfaceChunk = area.Chunks[altitude];
            }
            return terrain;
        }
    }
}