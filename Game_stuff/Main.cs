using System;
using System.IO;

using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Common.Input;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

using StbImageSharp;

namespace openTK_basics
{
    class Main : GameWindow
    {
        public Main(int width, int height, string title)
            : base(GameWindowSettings.Default, new NativeWindowSettings()
            {
                Title = title,
                Size = new Vector2i(width, height),
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

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);

            base.OnResize(e);
        }

        protected override void OnLoad()
        {
            IsVisible = true;

            // add Icon to window :)
            ImageResult loadedIcon;
            using (Stream stream = File.OpenRead("./../../../../images/bean.png")) loadedIcon = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
            Image _icon = new Image(loadedIcon.Width, loadedIcon.Height, loadedIcon.Data);
            Icon = new WindowIcon(_icon);

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
        }
    }
}
