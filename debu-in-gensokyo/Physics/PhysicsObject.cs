using Microsoft.Xna.Framework;

namespace DebuInGensokyo.Physics
{
    class PhysicsObject
    {
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 force;
        private Rectangle boundingBox;
        private int mass;
        public PhysicsObject(Vector2 position, Rectangle boundingBox, int mass)
        {
            this.position = position;
            this.mass = mass;
            this.boundingBox = boundingBox;
            velocity = Vector2.Zero;
            force = Vector2.Zero;
        }
        public void Update(GameTime time)
        {
            velocity += force * (float) time.ElapsedGameTime.TotalSeconds / mass;
            position += velocity;
        }
        public void ApplyForce(Vector2 force)
        {
            this.force += force;
        }
        public void ApplyVelocity(Vector2 velocity)
        {
            this.velocity += velocity;
        }
        public void Collide(CollisionPart part)
        {
            if ((Collision.HasTop(part) && velocity.Y > 0) || (Collision.HasBottom(part) && velocity.Y < 0))
            {
                velocity.Y = 0;
            }
            if ((Collision.HasRight(part) && velocity.X > 0) || (Collision.HasLeft(part) && velocity.X < 0))
            {
                velocity.X = 0;
            }
        }
        public void CollideWith(PhysicsObject another)
        {
            if (another.boundingBox.Intersects(this.boundingBox))
            {
                this.Collide(CollisionPart.Center); // TODO
            }
        }
        public Vector2 Position
        {
            get { return position; }
        }
        public Rectangle BoundingBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
        }
    }
}