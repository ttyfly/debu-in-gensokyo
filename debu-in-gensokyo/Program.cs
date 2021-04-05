using System;
using Microsoft.Xna.Framework;

namespace DebuInGensokyo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DebuInGensokyo game = new DebuInGensokyo())
            {
                game.Run();
            }
        }
    }
}
