using System;
using System.IO;

using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Common.Input;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

using StbImageSharp;

namespace openTK_basics
{
    class Game : GameWindow
    {
        public Game(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings()
            {
                Title = title,
                ClientSize = new Vector2i(width, height),
                WindowBorder = WindowBorder.Resizable,
                StartVisible = false,
                StartFocused = true,
                WindowState = WindowState.Normal,
                API = ContextAPI.OpenGL,
                Profile = ContextProfile.Core,
                APIVersion = new Version(3, 3)
            })
        {
            CenterWindow();
        }

        // This is what gets done on creating and opening the window
        protected override void OnLoad()
        {
            IsVisible = true;

            // add Icon to window :)
            ImageResult loadedIcon;
            using (Stream stream = File.OpenRead("./../../../../images/bean.png")) loadedIcon = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
            OpenTK.Windowing.Common.Input.Image _icon = new OpenTK.Windowing.Common.Input.Image(loadedIcon.Width, loadedIcon.Height, loadedIcon.Data);
            Icon = new WindowIcon(_icon);

            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            // More code goes here
        }

        // Function that does everything that needs to be done on rendering a frame
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            // More code goes here

            SwapBuffers();
        }

        // used to fix the window if it gets resized. That way it doesn'st stay with the old window size
        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }
    }
}
