using DebuInGensokyo.Utility;
using DebuInGensokyo.World.Ecosystem;

namespace DebuInGensokyo.World.Generator
{
    class SurfaceGenerator : IGenerator
    {
        public SurfaceGenerator() {}
        public Terrain apply(Terrain terrain)
        {
            foreach (Region region in terrain.Regions)
            {
                uint altitude = AttributeHelper.Get<EcosystemAttribute>(region.Ecosystem.GetType()).Altitude;
                for (int i = 0; i < terrain.Height; i++)
                {
                    if (i < altitude)
                    {
                        region.Chunks[i].FillWith(TileRepository.Instance.GetTile(1));
                    }
                    else
                    {
                        region.Chunks[i].FillWith(TileRepository.Instance.GetTile(0));
                    }
                }
                Chunk surfaceChunk = region.Chunks[altitude];
            }
            return terrain;
        }
    }
}