namespace DebuInGensokyo.World.Generator
{
    class SurfaceGenerator : IGenerator
    {
        public SurfaceGenerator() {}
        public Terrain apply(Terrain terrain)
        {
            return terrain;
        }
    }
}