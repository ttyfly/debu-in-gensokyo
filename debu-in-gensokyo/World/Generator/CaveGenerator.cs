namespace DebuInGensokyo.World.Generator
{
    // reference: https://blog.csdn.net/qq_33288536/article/details/81462894
    class CaveGenerator : IGenerator
    {
        public CaveGenerator() {}
        public Terrain apply(Terrain terrain)
        {
            return terrain;
        }
    }
}