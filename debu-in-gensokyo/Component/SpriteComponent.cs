using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DebuInGensokyo.Component
{
    class SpriteComponent : DrawableGameComponent
    {
        private List<Sprite> sprites;
        private SpriteBatch batch;
        public SpriteComponent(Game game) : base(game)
        {
            sprites = new List<Sprite>();
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            foreach (Sprite sprite in sprites)
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
            foreach (Sprite sprite in sprites)
            {
                sprite.Draw(batch, gameTime);
            }
            batch.End();
            base.Draw(gameTime);
        }
        public void register(Sprite sprite)
        {
            sprites.Add(sprite);
            sprite.Initialize();
        }
    }
}