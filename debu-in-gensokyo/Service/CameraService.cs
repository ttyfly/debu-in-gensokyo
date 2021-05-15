using Microsoft.Xna.Framework;

namespace DebuInGensokyo.Service
{
    class CameraService
    {
        Rectangle viewRect;
        public CameraService(Rectangle initialViewRect)
        {
            viewRect = initialViewRect;
        }
        public Rectangle ViewRect
        {
            get { return viewRect; }
        }
    }
}