using System;
using SharpDX.Direct2D1;
using SharpDX.Direct3D11;
using SharpDX.Toolkit.Direct2D.Test.CanvasStub;
using SharpDX.Toolkit.Graphics;
using SharpDX.Toolkit.Input;
using Buffer = SharpDX.Toolkit.Graphics.Buffer;
using Effect = SharpDX.Toolkit.Graphics.Effect;
using Texture2D = SharpDX.Toolkit.Graphics.Texture2D;

namespace SharpDX.Toolkit.Direct2D.Test {
    public class MyGame : Game {
        #region Fields

        private readonly DemoSurface _demoSurface;
        private readonly Direct2DService _direct2DService;
        private readonly Direct2DSystem _direct2DSystem;
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        private readonly KeyboardManager _manager;
        private readonly Random _random;
        private BasicEffect _basicEffect;
        private Effect _effect;
        private Buffer<ushort> _indexBuffer;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture2D;
        private Buffer<VertexPositionColor> _vertexBuffer;
        private VertexInputLayout _vertexInputLayout;
        public Canvas Canvas { get; private set; }

        #endregion

        public MyGame() {
            _graphicsDeviceManager = new GraphicsDeviceManager(this);
            _graphicsDeviceManager.DeviceCreationFlags |= DeviceCreationFlags.BgraSupport;

            _graphicsDeviceManager.DeviceCreationFlags |= DeviceCreationFlags.Debug;

            _direct2DService = new Direct2DService(_graphicsDeviceManager);

            Services.AddService<IDirect2DService>(_direct2DService);

            _direct2DSystem = new Direct2DSystem(this);

            _demoSurface = new DemoSurface(Services);
            //_direct2DSystem.Surfaces.Add(_demoSurface);
            _manager = new KeyboardManager(this);
            _random = new Random();
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent() {
            _effect = Content.Load<Effect>("Test.tkb");
            Load3DStuff();
            LoadCanvasStuff();

            base.LoadContent();
        }

        private void LoadCanvasStuff() {
            Canvas = new Canvas(this);

            var texture2D = Content.Load<Texture2D>("ghost.tkb");


            Canvas.PushObject(new CanvasTransform(Matrix3x2.Translation(100.0f, 100.0f)));
            Canvas.PushObject(new CanvasLine(new Vector2(0.0f, 0.0f), new Vector2(100.0f, 90.0f),
                Canvas.GetSolidColorBrush(Color.DeepSkyBlue), 5.0f));
            Canvas.PushObject(new CanvasLine(new Vector2(100.0f, 0.0f), new Vector2(200.0f, 90.0f),
                Canvas.GetSolidColorBrush(Color.DeepPink), 5.0f));
            Canvas.PushObject(new CanvasRectangle(new RectangleF(0.0f, 100.0f, 90.0f, 90.0f),
                Canvas.GetSolidColorBrush(Color.GhostWhite)));
            Canvas.PushObject(new CanvasRectangle(new RectangleF(100.0f, 100.0f, 90.0f, 90.0f),
                Canvas.GetSolidColorBrush(Color.DarkKhaki), true));
            Canvas.PushObject(new CanvasEllipse(new Ellipse(new Vector2(50.0f, 250.0f), 40.0f, 35.0f),
                Canvas.GetSolidColorBrush(Color.Gold)));
            Canvas.PushObject(new CanvasEllipse(new Ellipse(new Vector2(150.0f, 250.0f), 40.0f, 35.0f),
                Canvas.GetSolidColorBrush(Color.Orange), true));
            Canvas.PushObject(new CanvasTransform(Matrix3x2.Translation(200.0f, 400.0f)));
            Canvas.PushObject(new CanvasBitmap(texture2D));
            Factory factory = Canvas.Factory;
            Canvas.PushObject(
                new CanvasGeometry(
                    new RoundedRectangleGeometry(factory,
                        new RoundedRectangle {RadiusX = 20, RadiusY = 20, Rect = new RectangleF(300, 300, 100, 100)})
                    , Canvas.GetSolidColorBrush(Color.HotPink)));

            Canvas.PushObject(
                new CanvasGeometry(
                    new EllipseGeometry(factory, new Ellipse(new Vector2(400), 80, 80))
                    , Canvas.GetSolidColorBrush(Color.HotPink)));

            //Canvas.PushObject(new CanvasMetafile(@"Content\AN00932_.WMF"));

            Canvas.PushObject(new CanvasTransform(Matrix3x2.Identity));

            //  Canvas.ClearColor = Color.DeepPink.ChangeAlpha(0.1f);
            //Brush brush1 = Canvas.GetSolidColorBrush(Color.PaleVioletRed);
            //Brush brush2 = Canvas.GetSolidColorBrush(Color.Tan);
            //Brush brush3 = Canvas.GetSolidColorBrush(Color.Purple);

            //var styleProperties = new StrokeStyleProperties
            //{
            //    StartCap = CapStyle.Flat,
            //    EndCap = CapStyle.Flat,
            //    DashCap = CapStyle.Triangle,
            //    LineJoin = LineJoin.Miter,
            //    MiterLimit = 10.0f,
            //    DashStyle = DashStyle.DashDotDot,
            //    DashOffset = 0.0f
            //};
            //var strokeStyle = Canvas.GetStrokeStyle(styleProperties);


            //RectangleDrawing rect1 = new RectangleDrawing(new RectangleF(10, 10, 200, 200), brush1, 5.0f, strokeStyle);
            //RectangleDrawing rect3 = new RectangleDrawing(new RectangleF(300, 300, 100, 100), brush2);
            //RectangleDrawing rect4 = new RectangleDrawing(new RectangleF(450, 450, 100, 100), brush3);
            //Canvas.PushDrawing(rect1);
            //Canvas.PushDrawing(rect3);
            //Canvas.PushDrawing(rect4);

            //RoundedRectangleDrawing roundedRectangleDrawing = new RoundedRectangleDrawing(new RoundedRectangle() { RadiusX = 5, RadiusY = 5, Rect = new RectangleF(200, 10, 100, 100) }, brush3);
            //Canvas.PushDrawing(roundedRectangleDrawing);

            //Brush brush4=Canvas.GetSolidColorBrush(Color.DeepPink);
            //Drawing  drawing=new LineDrawing(new Vector2(50,50),new Vector2(150,240), brush4 ,10);
            //Canvas.PushDrawing(drawing);


            //Canvas.PushObject(new CanvasTransform(Matrix3x2.Translation(new Vector2(100.0f, 100.0f))));
        }

        private void Load3DStuff() {
            VertexPositionColor[] vertices = {
                new VertexPositionColor(new Vector3(-1.0f, +1.0f, -1.0f), Color.Red),
                new VertexPositionColor(new Vector3(+1.0f, +1.0f, -1.0f), Color.Black),
                new VertexPositionColor(new Vector3(-1.0f, -1.0f, -1.0f), Color.Yellow),
                new VertexPositionColor(new Vector3(+1.0f, -1.0f, -1.0f), Color.Green),
                new VertexPositionColor(new Vector3(-1.0f, +1.0f, +1.0f), Color.Magenta),
                new VertexPositionColor(new Vector3(+1.0f, +1.0f, +1.0f), Color.Blue),
                new VertexPositionColor(new Vector3(-1.0f, -1.0f, +1.0f), Color.White),
                new VertexPositionColor(new Vector3(+1.0f, -1.0f, +1.0f), Color.Cyan)
            };

            //var  vertices = new[]{
            //    new VertexPositionColorNormal(new Vector3(-1.0f, +1.0f, -1.0f), Vector3.Up, Color.Red),
            //    new VertexPositionColorNormal(new Vector3(+1.0f, +1.0f, -1.0f),Vector3.Left, Color.Black),
            //    new VertexPositionColorNormal(new Vector3(-1.0f, -1.0f, -1.0f),Vector3.ForwardRH, Color.Yellow),
            //    new VertexPositionColorNormal(new Vector3(+1.0f, -1.0f, -1.0f),Vector3.ForwardRH, Color.Green),
            //    new VertexPositionColorNormal(new Vector3(-1.0f, +1.0f, +1.0f),Vector3.BackwardRH, Color.Magenta),
            //    new VertexPositionColorNormal(new Vector3(+1.0f, +1.0f, +1.0f),Vector3.BackwardRH, Color.Blue),
            //    new VertexPositionColorNormal(new Vector3(-1.0f, -1.0f, +1.0f),Vector3.Right, Color.White),
            //    new VertexPositionColorNormal(new Vector3(+1.0f, -1.0f, +1.0f),Vector3.Down, Color.Cyan)
            //};
            _vertexBuffer = Buffer.Vertex.New(GraphicsDevice, vertices);
            _vertexInputLayout = VertexInputLayout.FromBuffer(0, _vertexBuffer);
            ushort[]
                indices = {
                    // front
                    0, 1, 2,
                    3, 2, 1,
                    // back
                    4, 5, 6,
                    7, 6, 5,
                    // left
                    0, 2, 6,
                    0, 6, 4,
                    // right
                    1, 5, 3,
                    3, 5, 7,
                    // top
                    0, 4, 1,
                    1, 4, 5,
                    // bottom
                    2, 6, 3,
                    6, 7, 3
                };
            _indexBuffer = Buffer.Index.New(GraphicsDevice, indices);
            _basicEffect = new BasicEffect(GraphicsDevice) {
                VertexColorEnabled = true,
            };

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture2D = Texture2D.New(GraphicsDevice, GraphicsDevice.BackBuffer.Width, GraphicsDevice.BackBuffer.Height,
                GraphicsDevice.BackBuffer.Format);
        }

        protected override void Update(GameTime time) {
            KeyboardState state = _manager.GetState();

            bool isKeyDown = state.IsKeyDown(Keys.Control);
            //if (isKeyDown) 
            {
                var f = (float) time.TotalGameTime.TotalSeconds;
                Matrix scaling = Matrix.Scaling(1f);
                Matrix rotate =
                    Matrix.RotationX(f)
                    *Matrix.RotationY(f*.7f)
                    *Matrix.RotationZ(f*1.6f)
                    ;

                Quaternion rotationYawPitchRoll = Quaternion.RotationYawPitchRoll(f, f*.7f, f*1.6f);
                Matrix rotationQuaternion = Matrix.RotationQuaternion(rotationYawPitchRoll);

                Matrix world = scaling*rotate;
                //world = rotationQuaternion;
                _basicEffect.World = world;
                _basicEffect.View = Matrix.LookAtRH(new Vector3(0, 0, -5), new Vector3(0, 0, 0), Vector3.UnitY);
                _basicEffect.Projection = Matrix.PerspectiveFovRH(MathUtil.PiOverFour,
                    (float) GraphicsDevice.BackBuffer.Width/GraphicsDevice.BackBuffer.Height, 0.1f, 100.0f);
                // _basicEffect.EnableDefaultLighting();

                //  _direct2DSystem.Update(time);
            }
            base.Update(time);
        }

        protected override void Draw(GameTime time) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            #region 3D cube

            GraphicsDevice.SetVertexBuffer(_vertexBuffer);
            GraphicsDevice.SetVertexInputLayout(_vertexInputLayout);
            GraphicsDevice.SetIndexBuffer(_indexBuffer, false);
            GraphicsDevice.SetRasterizerState(GraphicsDevice.RasterizerStates.CullNone);
            _basicEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.DrawIndexed(PrimitiveType.TriangleList, _indexBuffer.ElementCount);

            #endregion

            #region Copy of back buffer

            if (_texture2D.Width != GraphicsDevice.BackBuffer.Width ||
                _texture2D.Height != GraphicsDevice.BackBuffer.Height) {
                _texture2D.Dispose();
                _texture2D = Texture2D.New(GraphicsDevice, GraphicsDevice.BackBuffer.Width,
                    GraphicsDevice.BackBuffer.Height, GraphicsDevice.BackBuffer.Format);
            }
            GraphicsDevice.Copy(GraphicsDevice.BackBuffer, _texture2D);
            _spriteBatch.Begin(SpriteSortMode.Deferred, _effect);
            //_spriteBatch.Draw(_texture2D, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 0.5f,
            //    SpriteEffects.None, 0);

            _spriteBatch.Draw(_texture2D, new Rectangle(0, 0, _texture2D.Width/2, _texture2D.Height),
                new Rectangle(0, 0, _texture2D.Width/2, _texture2D.Height), Color.White);

            //_spriteBatch.Draw(_texture2D,Vector2.Zero, Color.White);
            _spriteBatch.End();

            #endregion

            // Canvas
            Canvas.Render();

            //_demoSurface.Text = Canvas.State.ToString();

            base.Draw(time);
        }

        public void PushSomeStuff() {
            int maxWidth = GraphicsDevice.BackBuffer.Width;
            int maxHeight = GraphicsDevice.BackBuffer.Height;
            float x = _random.NextFloat(0.0f, maxWidth);
            float y = _random.NextFloat(0.0f, maxHeight);
            float width = _random.NextFloat(0.0f, maxWidth - x);
            float height = _random.NextFloat(0.0f, maxHeight - y);
            var rectangleDrawing =
                new CanvasRectangle(
                    new RectangleF(x, y, width, height),
                    Canvas.GetSolidColorBrush(_random.NextColor()),
                    strokeWidth: _random.NextFloat(1.0f, 5.0f));
            //Canvas.PushObject(new CanvasTransform(Matrix3x2.Rotation(_random.NextFloat(0.0f,MathUtil.TwoPi),new Vector2(maxWidth / 2f,maxHeight/2f))));
            Canvas.PushObject(rectangleDrawing);
        }
    }
}