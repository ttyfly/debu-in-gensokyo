using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DebuInGensokyo.World;

namespace DebuInGensokyo.Component
{
    class TerrainComponent : DrawableGameComponent
    {
        Terrain terrain;
        SpriteBatch batch;
        public TerrainComponent(Game game) : base(game) {}
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        protected override void LoadContent()
        {
            batch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }
        protected override void UnloadContent()
        {
            batch.Dispose();
            base.UnloadContent();
        }
    }
}