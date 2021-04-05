using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DebuInGensokyo
{
    class DebuInGensokyo : Game
    {
        SpriteBatch batch;
        Texture2D texture;
        public DebuInGensokyo()
        {
            GraphicsDeviceManager gdm =  new GraphicsDeviceManager(this);

            gdm.PreferredBackBufferWidth = 960;
            gdm.PreferredBackBufferHeight = 580;
            gdm.IsFullScreen = false;
            gdm.SynchronizeWithVerticalRetrace = true;

            

            Content.RootDirectory = "content";
        }
        protected override void Initialize()
        {
            /* This is a nice place to start up the engine, after
            * loading configuration stuff in the constructor
            */
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Load textures, sounds, and so on in here...

            // Create the batch...
            batch = new SpriteBatch(GraphicsDevice);
            // ... then load a texture from ./Content/FNATexture.png
            texture = Content.Load<Texture2D>("player");

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            // Clean up after yourself!

            batch.Dispose();
            texture.Dispose();

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // Run game logic in here. Do NOT render anything here!
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Render stuff in here. Do NOT run game logic in here!
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the texture to the corner of the screen
            batch.Begin(
                SpriteSortMode.FrontToBack,
				BlendState.AlphaBlend,
				SamplerState.PointClamp,
				DepthStencilState.None,
				RasterizerState.CullCounterClockwise,
				null,
				Matrix.CreateScale(2)
            );
            batch.Draw(texture, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            batch.End();

            base.Draw(gameTime);
        }
    }
}