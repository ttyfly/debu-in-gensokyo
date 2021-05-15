using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DebuInGensokyo {
    class Player : BaseSprite
    {
        public Player(Texture2D texture) : base(texture, null, 0) {}
        public override void Update(GameTime time)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {

            }
            base.Update(time);
        }
    }
}