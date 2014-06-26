using System;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Direct3D11;
using SharpDX.DirectWrite;
using SharpDX.DXGI;
using SharpDX.IO;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;
using SharpDX.WIC;
using BitmapInterpolationMode = SharpDX.Direct2D1.BitmapInterpolationMode;
using Buffer = SharpDX.Toolkit.Graphics.Buffer;
using CommandList = SharpDX.Direct2D1.CommandList;
using Device = SharpDX.Direct3D11.Device;
using DeviceContext = SharpDX.Direct2D1.DeviceContext;
using Factory1 = SharpDX.DirectWrite.Factory1;
using Image = SharpDX.Direct2D1.Image;
using PixelFormat = SharpDX.WIC.PixelFormat;
using Texture2D = SharpDX.Toolkit.Graphics.Texture2D;

namespace App1 {
    internal class MyGame : Game {
        #region Private fields

        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        private readonly Direct2DService _service;
        private BasicEffect _basicEffect;
        private SolidColorBrush _brush;
        private Buffer<VertexPositionColor> _buffer;
        private VertexInputLayout _bufferLayout;
        private CommandList _commandList;
        private Bitmap1 _example1Bitmap;
        private SolidColorBrush _example2Brush1;
        private SolidColorBrush _example2Brush2;
        private Ellipse _example2Ellipse;
        private StrokeStyle _example2StrokeStyle;
        private SolidColorBrush _example3Brush1;
        private LinearGradientBrush _example3Brush2;
        private PathGeometry _example3Geometry;
        private SolidColorBrush _example4Brush;
        private TextFormat _example4TextFormat;
        private ShaderResourceView _shaderResourceView;
        private SpriteBatch _spriteBatch;
        private Bitmap1 _target;
        private Texture2D _texture2D;

        #endregion

        public MyGame() {
            _graphicsDeviceManager = new GraphicsDeviceManager(this) {
                PreferredBackBufferFormat = Format.B8G8R8A8_UNorm,
                DeviceCreationFlags = DeviceCreationFlags.BgraSupport | DeviceCreationFlags.Debug
            };

            _service = new Direct2DService(_graphicsDeviceManager);
            Services.AddService(typeof (IDirect2DService), _service);
        }


        protected override void LoadContent() {
            VertexPositionColor[] vertices = {
                new VertexPositionColor(new Vector3(-0.5f, -0.5f, 0), Color.Cyan),
                new VertexPositionColor(new Vector3(0.5f, -0.5f, 0), Color.Magenta),
                new VertexPositionColor(new Vector3(-0.5f, 0.5f, 0), Color.Black),
                new VertexPositionColor(new Vector3(0.5f, 0.5f, 0), Color.Yellow),
                new VertexPositionColor(new Vector3(-0.5f, 0.5f, 0), Color.Black),
                new VertexPositionColor(new Vector3(0.5f, -0.5f, 0), Color.Magenta)
            };

            _buffer = Buffer.Vertex.New(GraphicsDevice, vertices);
            _bufferLayout = VertexInputLayout.FromBuffer(0, _buffer);
            _basicEffect = new BasicEffect(GraphicsDevice) {VertexColorEnabled = true};

            // from http://msdn.microsoft.com/en-us/library/windows/desktop/dd756671(v=vs.85).aspx

            // example 1
            DeviceContext context = _service.DeviceContext;
            using (var factory = new ImagingFactory())
            using (var decoder = new PngBitmapDecoder(factory))
            using (var fileStream =
                new NativeFileStream("Content\\sample.png", NativeFileMode.Open, NativeFileAccess.Read))
            using (var wicStream = new WICStream(factory, fileStream)) {
                decoder.Initialize(wicStream, DecodeOptions.CacheOnLoad);
                using (BitmapFrameDecode decode = decoder.GetFrame(0))
                using (var converter = new FormatConverter(factory)) {
                    converter.Initialize(decode, PixelFormat.Format32bppPBGRA);
                    DeviceContext direct2DContext = context;
                    _example1Bitmap = Bitmap1.FromWicBitmap(direct2DContext, converter);
                }
            }

            // example 2
            _example2Brush2 = new SolidColorBrush(context, Color.Black);
            _example2Brush1 = new SolidColorBrush(context, Color.Silver);
            _example2Ellipse = new Ellipse(new Vector2(100.0f, 100.0f), 75.0f, 50.0f);
            var styleProperties = new StrokeStyleProperties {
                StartCap = CapStyle.Flat,
                EndCap = CapStyle.Flat,
                DashCap = CapStyle.Triangle,
                LineJoin = LineJoin.Miter,
                MiterLimit = 10.0f,
                DashStyle = DashStyle.DashDotDot,
                DashOffset = 0.0f
            };
            _example2StrokeStyle = new StrokeStyle(context.Factory, styleProperties);

            // example 3
            _example3Geometry = new PathGeometry(context.Factory);
            using (GeometrySink sink = _example3Geometry.Open()) {
                sink.BeginFigure(new Vector2(0.0f, 0.0f), FigureBegin.Filled);
                sink.AddLine(new Vector2(200.0f, 0.0f));
                sink.AddBezier(new BezierSegment {
                    Point1 = new Vector2(150.0f, 50.0f),
                    Point2 = new Vector2(150.0f, 150.0f),
                    Point3 = new Vector2(200.0f, 200.0f),
                });
                sink.AddLine(new Vector2(0.0f, 200.0f));
                sink.AddBezier(new BezierSegment {
                    Point1 = new Vector2(50.0f, 150.0f),
                    Point2 = new Vector2(50.0f, 50.0f),
                    Point3 = new Vector2(0.0f, 0.0f),
                });
                sink.EndFigure(FigureEnd.Closed);
                sink.Close();
            }

            _example3Brush1 = new SolidColorBrush(context, Color4.Black);

            using (var gradientStopCollection = new GradientStopCollection(context, new[] {
                new GradientStop {Color = new Color4(0.0f, 1.0f, 1.0f, 0.25f), Position = 0.0f},
                new GradientStop {Color = new Color4(0.0f, 0.0f, 1.0f, 1.0f), Position = 1.0f}
            })) {
                _example3Brush2 = new LinearGradientBrush(context,
                    new LinearGradientBrushProperties {
                        StartPoint = new Vector2(100.0f, 0.0f),
                        EndPoint = new Vector2(100.0f, 200.0f)
                    }, gradientStopCollection);
            }

            // example 4
            Factory1 directWriteFactory = _service.DirectWriteFactory;
            _example4TextFormat = new TextFormat(directWriteFactory, "Segoe UI", 32.0f);
            _example4Brush = new SolidColorBrush(context, Color4.Black);

            ////////////////////////////////


            var texture2D11 = new SharpDX.Direct3D11.Texture2D(GraphicsDevice,
                new Texture2DDescription {
                    BindFlags = BindFlags.RenderTarget | BindFlags.ShaderResource,
                    Usage = ResourceUsage.Default,
                    Format = Format.B8G8R8A8_UNorm,
                    Width = 512,
                    Height = 512,
                    SampleDescription = new SampleDescription(1, 0),
                    ArraySize = 1
                });
            _texture2D = Texture2D.New(GraphicsDevice, texture2D11);
            _shaderResourceView = new ShaderResourceView(GraphicsDevice, _texture2D);
            using (var queryInterface = texture2D11.QueryInterface<Resource1>())
            using (Surface surface2 = new Surface2(queryInterface, 0)) {
                _target = new Bitmap1(_service.DeviceContext, surface2);
            }

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _brush = new SolidColorBrush(_service.DeviceContext, Color.DarkKhaki);


            _commandList = new CommandList(context);
            context.Target = _commandList;
            using (context.Target) {
                context.BeginDraw();
                context.FillEllipse(new Ellipse(new Vector2(50, 50), 20, 20), _example3Brush2);
                context.EndDraw();
            }
            _commandList.Close();
            base.LoadContent();
        }


        protected override void Update(GameTime time) {
            var t = (float) time.TotalGameTime.TotalMilliseconds;
            float width = GraphicsDevice.Viewport.Width;
            float height = GraphicsDevice.Viewport.Height;
            float cx = width/2.0f;
            float cy = height/2.0f;
            float scaleX = 100.0f*(float) (1 + Math.Abs(0.5 + 0.5*Math.Sin(t/1000.0f*MathUtil.Pi)));
            float scaleY = 100.0f*(float) (1 + Math.Abs(0.5 + 0.5*Math.Sin((t + 600.0f)/1000.0f*MathUtil.Pi)));
            float angle = t/1000.0f%MathUtil.TwoPi;
            Matrix world =
                // Rotate around a point but keep head up
                Matrix.RotationZ(angle)*(Matrix.Translation(-0.5f, -0.5f, 0.0f)*Matrix.RotationZ(MathUtil.Pi - angle))
                    // Swimming effect
                *Matrix.Scaling(scaleX, scaleY, 1.0f)
                    // Center
                *Matrix.Translation(cx, cy, 0.0f);
            _basicEffect.World = world;
            _basicEffect.View = Matrix.Identity;
            _basicEffect.Projection = Matrix.OrthoOffCenterRH(0, width, height, 0, 0, 1);
            base.Update(time);
        }

        protected override void Draw(GameTime time) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            /* Direct2D / DirectWrite example */
            DeviceContext context = _service.DeviceContext;

            // Caution, when accessing context.Target, It must be disposed as the returned object is created everytime
            // we access the property, incrementing the reference counter on it
            _service.SetDefaultDeviceContextTarget();
            using (Image target = context.Target) {
                if (context != null && target != null) {
                    context.BeginDraw();
                    // example 1
                    context.Transform = Matrix3x2.Translation(new Vector2(20.0f, 20.0f));
                    context.DrawBitmap(_example1Bitmap, 0.75f, BitmapInterpolationMode.NearestNeighbor);
                    // example 2
                    context.Transform = Matrix3x2.Translation(new Vector2(220.0f, 20.0f));
                    context.FillEllipse(_example2Ellipse, _example2Brush1);
                    context.DrawEllipse(_example2Ellipse, _example2Brush2, 10.0f, _example2StrokeStyle);
                    // example 3
                    context.Transform = Matrix3x2.Translation(new Vector2(20.0f, 220.0f));
                    context.DrawGeometry(_example3Geometry, _example3Brush1, 10.0f);
                    context.FillGeometry(_example3Geometry, _example3Brush2);
                    // example 4
                    context.Transform = Matrix3x2.Translation(new Vector2(220.0f, 220.0f));
                    var rect = new RectangleF(20.0f, 20.0f, 200.0f, 200.0f);
                    context.DrawText("Hello, DirectWrite !", _example4TextFormat, rect, _example4Brush);
                    context.EndDraw();
                }
            }

            context.Target = _target;
            using (context.Target) {
                context.BeginDraw();
                context.Transform = Matrix3x2.Translation(new Vector2(5, 5));
                // context.FillEllipse(new Ellipse(new Vector2(50, 50), 50, 50), _example3Brush2);
                context.DrawImage(_commandList);
                context.EndDraw();
            }
            _spriteBatch.Begin();
            _spriteBatch.Draw(_shaderResourceView, Vector2.Zero, Color.White);
            _spriteBatch.End();
            /* Direct3D example */
            GraphicsDevice.SetVertexBuffer(_buffer);
            GraphicsDevice.SetVertexInputLayout(_bufferLayout);
            _basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.Draw(PrimitiveType.TriangleList, _buffer.ElementCount);


            base.Draw(time);
        }

        public static SharpDX.Direct3D11.Texture2D CreateTexture2DFromBitmap(Device device, Bitmap1 bitmap) {
            DataRectangle map = bitmap.Map(MapOptions.Read);
            var desc = new Texture2DDescription {
                Width = (int) bitmap.Size.Width,
                Height = (int) bitmap.Size.Height,
                ArraySize = 1,
                BindFlags = BindFlags.ShaderResource,
                Usage = ResourceUsage.Immutable,
                CpuAccessFlags = CpuAccessFlags.None,
                Format = Format.R8G8B8A8_UNorm,
                MipLevels = 1,
                OptionFlags = ResourceOptionFlags.None,
                SampleDescription = new SampleDescription(1, 0),
            };

            // Allocate DataStream to receive the WIC image pixels                         
            var texture = new SharpDX.Direct3D11.Texture2D(device, desc, map);
            bitmap.Unmap();
            return texture;
        }
    }
}