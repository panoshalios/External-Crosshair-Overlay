using System;
using System.Linq;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;

namespace Hacks
{
    public class ExternalCrosshair
    {
        public int CrosshairSize;
        private Device directXDevice;
        private CustomVertex.TransformedColored[] vertices;

        private Point coordinatesToDraw;
        public Point CoordinatesToDraw
        {
            get
            {
                return coordinatesToDraw;
            }
            set
            {
                coordinatesToDraw = value;
                //Horizontal
                vertices[0].Position = new Vector4(value.X - CrosshairSize, value.Y, 0.0f, 1.0f);
                vertices[1].Position = new Vector4(value.X + CrosshairSize, value.Y, 0.0f, 1.0f);
                //Vertical
                vertices[2].Position = new Vector4(value.X, value.Y - CrosshairSize, 0.0f, 1.0f);
                vertices[3].Position = new Vector4(value.X, value.Y + CrosshairSize, 0.0f, 1.0f);

            }
        }

        private Color crosshairColour;
        public Color CrosshairColour
        {
            get
            {
                return crosshairColour;
            }
            set
            {
                crosshairColour = value;
                for (int i = 0; i < vertices.Count(); i++)
                {
                    vertices[i].Color = value.ToArgb();
                }
            }
        }

        private IntPtr processHandle;

        /// <summary>
        /// Initializes a new instance of the Hacks.ExternalCrosshair class
        /// </summary>
        /// <param name="handle">Points to the destination of drawing</param>
        public ExternalCrosshair(IntPtr handle, int crosshairSize)
        {
            vertices = new CustomVertex.TransformedColored[4];
            CrosshairSize = crosshairSize;
            CrosshairColour = Color.Blue;
            CoordinatesToDraw = new Point();
            processHandle = handle;
            InitializeDevice(handle);
        }

        public void DrawCrosshair()
        {
            directXDevice.BeginScene();
            ClearDevice();
            
            //Draws the crosshair
            directXDevice.DrawUserPrimitives(PrimitiveType.LineList, 2, vertices);

            directXDevice.EndScene();
            try
            {
                directXDevice.Present();
            }
            catch
            {
                //InitializeDevice(processHandle);
            }
        }

        private void InitializeDevice(IntPtr handle)
        {
            var pp = new PresentParameters()
            {
                Windowed = true,
                SwapEffect = SwapEffect.Discard,
                BackBufferFormat = Format.A8R8G8B8
            };

            directXDevice = new Device(0, DeviceType.Hardware, handle, CreateFlags.HardwareVertexProcessing, pp);
            directXDevice.VertexFormat = CustomVertex.TransformedColored.Format;
        }

        public void ClearDevice()
        {
            directXDevice.Clear(ClearFlags.Target, Color.FromArgb(0, 0, 0, 0), 1.0f, 0);
        }

        public void Dispose()
        {
            if (!directXDevice.Disposed)
                directXDevice.Dispose();
        }
    }
}
