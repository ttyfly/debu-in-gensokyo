using System;
using Microsoft.Xna.Framework;

namespace DebuInGensokyo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game g = new Game())
            {
                new GraphicsDeviceManager(g);
                g.Run();
            }
        }
    }
}
