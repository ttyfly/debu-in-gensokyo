using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DebuInGensokyo.Utility;
using DebuInGensokyo.Physics;

namespace DebuInGensokyo
{
    class BaseSprite
    {
        protected Transform transform;
        protected Texture2D texture;
        protected PhysicsObject physicsObject;
        protected int layerDepth;
        public BaseSprite(Texture2D texture, PhysicsObject physicsObject, int layerDepth)
        {
            this.texture = texture;
            this.physicsObject = physicsObject;
            this.layerDepth = layerDepth;
            transform = new Transform();
        }
        public virtual void Initialize()
        {

        }
        public virtual void Update(GameTime time)
        {
            if (physicsObject != null)
            {
                physicsObject.Update(time);
            }
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
        public virtual void OnCollide(CollisionPart part)
        {
            physicsObject.Collide(part);
        }
        public Transform Transform
        {
            get { return transform; }
        }
        public PhysicsObject PhysicsObject
        {
            get { return physicsObject; }
        }
    }
}