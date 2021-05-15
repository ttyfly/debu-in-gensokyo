using Microsoft.Xna.Framework;

namespace DebuInGensokyo.Physics
{
    enum CollisionPart {
        None = 0x00,
        Top = 0x01,
        Bottom = 0x02,
        Left = 0x04,
        Right = 0x08,
        Center = 0x10,
    }
    class Collision
    {
        public static bool HasTop(CollisionPart part)
        {
            return (part & CollisionPart.Top) != 0;
        }
        public static bool HasBottom(CollisionPart part)
        {
            return (part & CollisionPart.Bottom) != 0;
        }
        public static bool HasLeft(CollisionPart part)
        {
            return (part & CollisionPart.Left) != 0;
        }
        public static bool HasRight(CollisionPart part)
        {
            return (part & CollisionPart.Right) != 0;
        }
    }
}