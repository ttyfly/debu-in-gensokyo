using Microsoft.Xna.Framework;
using DebuInGensokyo.World.Ecosystem;
using DebuInGensokyo.World.Generator;
using System;

namespace DebuInGensokyo.World
{
    class Terrain
    {
        private uint width; // chunks
        private uint height; // chunks
        private Area[] areas;
        public Terrain(uint width, uint height)
        {
            this.width = width;
            this.height = height;
            areas = new Area[width];
            for (int i = 0; i < width; i++)
            {
                areas[i] = new Area(height);
            }
        }
        public void Generate(IGenerator[] generators)
        {
            foreach (IGenerator generator in generators)
            {
                generator.apply(this);
            }
        }
        public Area[] Areas
        {
            get { return areas; }
        }
        public Chunk GetChunk(int x, int y)
        {
            return areas[x].Chunks[y];
        }
        public uint Width
        {
            get { return width; }
        }
        public uint Height
        {
            get { return height; }
        }
    }
    class Area
    {
        private IEcosystem ecosystem;
        private Chunk[] chunks;
        public Area(uint height, IEcosystem ecosystem)
        {
            chunks = new Chunk[height];
            for (int i = 0; i < height; i++)
            {
                chunks[i] = new Chunk();
            }
            this.ecosystem = ecosystem;
        }
        public Area(uint height) : this(height, null) {}
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
    class Chunk
    {
        private uint[,] tiles;
        public Chunk()
        {
            tiles = new uint[128, 72];
        }
        public uint[,] Tiles
        {
            get { return tiles; }
        }
        public void FillWith(uint tile)
        {
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 72; j++)
                {
                    tiles[i, j] = tile;
                }
            }
        }
    }
}