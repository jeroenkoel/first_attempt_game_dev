using System;

using openTK_basics;

namespace Game_stuff
{
    internal class Program
    {
        static void Main()
        {
            using (Game window = new Game(1920, 1000, "test window"))
            {
                window.Run();
            }
        }
    }
}