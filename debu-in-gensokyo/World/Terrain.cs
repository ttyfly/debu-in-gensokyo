using DebuInGensokyo.World.Generator;
using DebuInGensokyo.Physics;
using Microsoft.Xna.Framework;

namespace DebuInGensokyo.World
{
    class Terrain
    {
        private int width; // chunks
        private int height; // chunks
        private Region[] regions;
        public Terrain(int width, int height)
        {
            this.width = width;
            this.height = height;
            regions = new Region[width];
            for (int i = 0; i < width; i++)
            {
                regions[i] = new Region(height);
            }
        }
        public void Generate(IGenerator[] generators)
        {
            foreach (IGenerator generator in generators)
            {
                generator.apply(this);
            }
        }
        public Region[] Regions
        {
            get { return regions; }
        }
        public Chunk GetChunk(int x, int y)
        {
            return regions[x].Chunks[y];
        }
        public Tile GetTile(int x, int y)
        {
            return regions[x / Chunk.WIDTH]
                    .Chunks[y / Chunk.HEIGHT]
                    .Tiles[x % Chunk.WIDTH, y % Chunk.HEIGHT];
        }
        public Tile GetTileByPixel(int x, int y)
        {
            return GetTile(x / Tile.WIDTH, Chunk.HEIGHT * this.Height - y / Tile.HEIGHT - 1);
        }
        public CollisionPart CollideWith(Rectangle rectangle)
        {
            CollisionPart part = CollisionPart.None;
            for (int x = rectangle.Left; x < rectangle.Right; x += Tile.WIDTH)
            {
                if (GetTileByPixel(x, rectangle.Top - 1).ID != 0)
                {
                    part |= CollisionPart.Top;
                }
                if (GetTileByPixel(x, rectangle.Bottom + 1).ID != 0)
                {
                    part |= CollisionPart.Bottom;
                }
            }
            for (int y = rectangle.Top; y < rectangle.Bottom; y += Tile.HEIGHT)
            {
                if (GetTileByPixel(rectangle.Left - 1, y).ID != 0)
                {
                    part |= CollisionPart.Left;
                }
                if (GetTileByPixel(rectangle.Right + 1, y).ID != 0)
                {
                    part |= CollisionPart.Right;
                }
            }
            return part;
        }
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
    }
}