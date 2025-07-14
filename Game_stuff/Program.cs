using System;
using OpenTK.Windowing.GraphicsLibraryFramework;
using openTK_basics;

namespace Game_stuff
{
    internal class Program
    {
        static void Main()
        {
            using Main window = new Main(1920, 1000, "test window");
            window.Run();
        }
    }
}