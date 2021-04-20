using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DebuInGensokyo.Utility;

namespace DebuInGensokyo
{
    class Sprite
    {
        protected Transform transform;
        protected Texture2D texture;
        protected int layerDepth;
        public Sprite(Texture2D texture, int layerDepth)
        {
            transform = new Transform();
            this.texture = texture;
            this.layerDepth = layerDepth;
        }
        public virtual void Initialize()
        {

        }
        public virtual void Update(GameTime time)
        {

        }
        public virtual bool isDead()
        {
            return false;
        }
        public virtual void Draw(SpriteBatch batch, GameTime time)
        {
            batch.Draw(
                texture,
                transform.position,
                null,
                Color.White,
                transform.rotation,
                Vector2.Zero,
                transform.scale,
                SpriteEffects.None,
                layerDepth
            );
        }
        public Transform Transform
        {
            get { return transform; }
        }
    }
}