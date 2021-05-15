using Microsoft.Xna.Framework;
using DebuInGensokyo.Component;
using DebuInGensokyo.World;
using DebuInGensokyo.Physics;

namespace DebuInGensokyo.Service
{
    class TerrainService
    {
        private TerrainComponent component;
        private Terrain terrain;
        public TerrainService(TerrainComponent terrainComponent)
        {
            component = terrainComponent;
            terrain = terrainComponent.Terrain;
        }
        public CollisionPart CollideWith(BaseSprite sprite)
        {
            if (sprite.PhysicsObject != null)
            {
                Rectangle boundingBox = sprite.PhysicsObject.BoundingBox;
                Rectangle absBox = new Rectangle(
                    boundingBox.X + (int)sprite.Transform.position.X,
                    boundingBox.Y + (int)sprite.Transform.position.Y,
                    boundingBox.Width,
                    boundingBox.Height
                );
                return terrain.CollideWith(absBox);
            }
            else
            {
                return CollisionPart.None;
            }
        }
    }
}