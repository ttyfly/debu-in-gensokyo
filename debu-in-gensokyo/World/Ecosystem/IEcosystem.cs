using Microsoft.Xna.Framework;

namespace DebuInGensokyo.World.Ecosystem
{
    enum EcosystemType
    {
        Ground,
        Sky,
        Underground,
    }
    interface IEcosystem
    {
        void Generate();
    }
}