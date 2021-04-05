using Microsoft.Xna.Framework;

namespace DebuInGensokyo.World.Ecosystem
{
    abstract class BaseEcosystem
    {
        public abstract Rectangle getMinSize();
        public abstract Rectangle getMaxSize();
        public abstract Rectangle getPossibleArea();
        public abstract void Generate();
    }
}