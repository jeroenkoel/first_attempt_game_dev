using System;
using System.IO;

using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Common.Input;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

using StbImageSharp;

using Shaders;

namespace openTK_basics
{
    class Game : GameWindow
    {

        // vertices cooridinates for the triangle
        float[] vertices = {
            -0.5f, -0.5f, 0.0f,
            0.5f, -0.5f, 0.0f,
            0.0f, 0.5f, 0.0f
        };
        
        // a buffer for the vertices
        int VertexBufferObject;

        // a VBO
        int VertexArrayObject;

        // The shader we will be using
        Shader shader;

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

            // loading the shaders
            shader = new Shader("./../../../../shaders/shader.vert", "./../../../../shaders/shader.frag");

            // Create the VBO
            VertexBufferObject = GL.GenBuffer();
            // Create the VAO
            VertexArrayObject = GL.GenVertexArray();

            // 1. Bind the VAO
            GL.BindVertexArray(VertexArrayObject);

            // 2. copy our vertices array in a buffer for OpenGL to use
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            // 3. then set our vertex attributes pointers
            GL.VertexAttribPointer(shader.GetAttribLocation("aPosition"), 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        // Function that does everything that needs to be done on rendering a frame
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            // More code goes here

            // Drawing the triangle on every frame
            shader.Use();
            GL.BindVertexArray(VertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

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

        protected override void OnUnload()
        {
            base.OnUnload();

            // More code goes here

            shader.Dispose();
        }
    }
}
