using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DebuInGensokyo
{
    class Sprite
    {
        protected Utility.Transform transform;
        protected Texture2D texture;
        protected int layerDepth;
        public Sprite(Texture2D texture)
        {
            this.texture = texture;
        }
        public virtual void Initialize()
        {

        }
        public virtual void Update()
        {

        }
        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, transform.position, null, Color.White, transform.rotation, Vector2.Zero, transform.scale, SpriteEffects.None, layerDepth);
        }
    }
}