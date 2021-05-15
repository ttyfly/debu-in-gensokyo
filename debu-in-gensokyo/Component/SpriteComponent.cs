using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DebuInGensokyo.Component
{
    class SpriteComponent : DrawableGameComponent
    {
        private List<BaseSprite> sprites;
        private SpriteBatch batch;
        public SpriteComponent(Game game) : base(game)
        {
            sprites = new List<BaseSprite>();
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            foreach (BaseSprite sprite in sprites)
            {
                sprite.Update(gameTime);
                if (sprite.isDead())
                {
                    sprites.Remove(sprite);
                }
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            batch.Begin(
                SpriteSortMode.FrontToBack,
				BlendState.AlphaBlend,
				SamplerState.PointClamp,
				DepthStencilState.None,
				RasterizerState.CullCounterClockwise,
				null,
				Matrix.CreateScale(2)
            );
            foreach (BaseSprite sprite in sprites)
            {
                sprite.Draw(batch, gameTime);
            }
            batch.End();
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
        public void register(BaseSprite sprite)
        {
            sprites.Add(sprite);
            sprite.Initialize();
        }
    }
}