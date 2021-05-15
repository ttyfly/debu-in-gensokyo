namespace DebuInGensokyo.World
{
    class Chunk
    {
        public const int WIDTH = 128;
        public const int HEIGHT = 72;
        private Tile[,] tiles;
        public Chunk()
        {
            tiles = new Tile[WIDTH, HEIGHT];
        }
        public Tile[,] Tiles
        {
            get { return tiles; }
        }
        public void FillWith(Tile tile)
        {
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    tiles[i, j] = tile;
                }
            }
        }
    }
}