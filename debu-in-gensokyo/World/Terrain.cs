using Microsoft.Xna.Framework;
using DebuInGensokyo.World.Ecosystem;

namespace DebuInGensokyo.World
{
    class Terrain
    {
        private uint width; // chunks
        private uint height; // chunks
        private Chunk[,] chunks;
        public Terrain(uint width, uint height)
        {
            this.width = width;
            this.height = height;
            this.chunks = new Chunk[width, height];
        }
    }
    class Chunk
    {
        private BaseEcosystem ecosystem;
        private uint[,] blocks;
        public Chunk()
        {
            blocks = new uint[128, 128];
            ecosystem = null;
        }
    }
}