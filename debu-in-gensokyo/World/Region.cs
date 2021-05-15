using DebuInGensokyo.World.Ecosystem;

namespace DebuInGensokyo.World
{
    class Region
    {
        private IEcosystem ecosystem;
        private Chunk[] chunks;
        public Region(int height, IEcosystem ecosystem)
        {
            chunks = new Chunk[height];
            for (int i = 0; i < height; i++)
            {
                chunks[i] = new Chunk();
            }
            this.ecosystem = ecosystem;
        }
        public Region(int height) : this(height, null) {}
        public Chunk[] Chunks
        {
            get { return chunks; }
        }
        public IEcosystem Ecosystem
        {
            get { return ecosystem; }
            set { ecosystem = value; }
        }
    }

}