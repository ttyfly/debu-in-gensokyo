using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using DebuInGensokyo.World;
using DebuInGensokyo.Service;
using DebuInGensokyo.World.Generator;
using DebuInGensokyo.World.Ecosystem;

namespace DebuInGensokyo.Component
{
    class TerrainComponent : DrawableGameComponent
    {
        public const int textureWidth = 2; // tiles
        public const int textureHeight = 1; // tiles
        public const int terrainWidth = 16; // chunks
        public const int terrainHeight = 16; // chunks
        private Terrain terrain;
        private Texture2D terrainTexture;
        private SpriteBatch batch;
        private CameraService camera;
        private List<IEcosystem> ecosystems;
        public TerrainComponent(Game game) : base(game) {
            ecosystems = new List<IEcosystem>();
        }
        public override void Initialize()
        {
            camera = (CameraService)Game.Services.GetService(typeof(CameraService));
            ecosystems.Add(new HumanVillage());
            terrain = new Terrain(terrainWidth, terrainHeight);
            new EcosystemGenerator(ecosystems).apply(terrain);
            new SurfaceGenerator().apply(terrain);
            for (int i = 0; i < TileRepository.Instance.Size; i++)
            {
                Rectangle textureRectangle = new Rectangle(
                    (i % textureWidth) * Tile.WIDTH,
                    (i / textureWidth) * Tile.HEIGHT,
                    Tile.WIDTH,
                    Tile.HEIGHT
                );
                TileRepository.Instance.GetTile(i).TextureRectangle = textureRectangle;
            }
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            batch.Begin(
                SpriteSortMode.FrontToBack,
				BlendState.AlphaBlend,
				SamplerState.PointClamp,
				DepthStencilState.None,
				RasterizerState.CullCounterClockwise,
				null,
				Matrix.CreateScale(2)
            );
            Vector2 drawOffset = -new Vector2(
                camera.ViewRect.Top % Tile.HEIGHT,
                (terrain.Height * Chunk.HEIGHT * Tile.HEIGHT - camera.ViewRect.Bottom) % Tile.WIDTH
            );
            int drawLeft = camera.ViewRect.Left / Tile.WIDTH;
            int drawBottom = (terrain.Height * Chunk.HEIGHT * Tile.HEIGHT - camera.ViewRect.Bottom) / Tile.HEIGHT;
            int drawWidth = camera.ViewRect.Width / Tile.WIDTH + 2;
            int drawHeight = camera.ViewRect.Height / Tile.HEIGHT + 2;
            for (int x = 0; x < drawWidth; x++)
            {
                for (int y = 0; y < drawHeight; y++)
                {
                    Tile tile = terrain.GetTile(x + drawLeft, y + drawBottom);
                    batch.Draw(terrainTexture, new Vector2(x * Tile.WIDTH, camera.ViewRect.Height - y * Tile.HEIGHT) + drawOffset,
                        tile.TextureRectangle, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                }
            }
            batch.End();
            base.Draw(gameTime);
        }
        protected override void LoadContent()
        {
            batch = new SpriteBatch(GraphicsDevice);
            terrainTexture = Game.Content.Load<Texture2D>("terrain");
            base.LoadContent();
        }
        protected override void UnloadContent()
        {
            batch.Dispose();
            terrainTexture.Dispose();
            base.UnloadContent();
        }
        public Terrain Terrain
        {
            get { return terrain; }
        }
    }
}