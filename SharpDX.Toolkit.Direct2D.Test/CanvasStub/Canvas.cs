// TODO : unsolved stuff
// Out of memory
// Drawing before breaks 3D
// ToDispose vs ToDisposeContent
// Dispose(bool) usage | bitmap1
// Encompass drawing inside a transform ?
// Implement append drawing

using System;
using System.Collections.Generic;
using SharpDX.Direct2D1;
using SharpDX.Toolkit.Graphics;

namespace SharpDX.Toolkit.Direct2D.Test.CanvasStub {
    public class Canvas : Component {
        #region Private fields

        private readonly Game _game;
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        private readonly List<CanvasObject> _objects;
        private readonly Queue<CanvasObject> _queue;
        private readonly IDirect2DService _service;
        private readonly SpriteBatch _spriteBatch;
        private Bitmap1 _bitmap1;
        private RenderTarget2D _renderTarget2D;

        #endregion

        #region Public constructor

        public Canvas(Game game) {
            if (game == null) throw new ArgumentNullException("game");
            _game = game;


            // TODO : check that game has the services
            _service = game.Services.GetService<IDirect2DService>();
            _graphicsDeviceManager = (GraphicsDeviceManager) game.Services.GetService<IGraphicsDeviceManager>();
            _graphicsDeviceManager.DeviceChangeBegin += _graphicsDeviceManager_DeviceChangeBegin;
            _graphicsDeviceManager.DeviceChangeEnd += _graphicsDeviceManager_DeviceChangeEnd;

            GraphicsDevice graphicsDevice = _game.GraphicsDevice;
            _spriteBatch = new SpriteBatch(graphicsDevice);

            // Set default values for this class
            _objects = new List<CanvasObject>();
            State = CanvasState.Refresh;
            _queue = new Queue<CanvasObject>();


        }

        public Factory Direct2DFactory {
            get { return _service.Device.Factory; }
        }

        private void _graphicsDeviceManager_DeviceChangeBegin(object sender, EventArgs e) {
            RemoveAndDispose(ref _renderTarget2D);
            RemoveAndDispose(ref _bitmap1);
        }

        private void _graphicsDeviceManager_DeviceChangeEnd(object sender, EventArgs e) {
            GraphicsDevice graphicsDevice = _game.GraphicsDevice;
            RenderTarget2D backBuffer = graphicsDevice.BackBuffer;
            _renderTarget2D =
                ToDispose(RenderTarget2D.New(graphicsDevice, backBuffer.Width, backBuffer.Height, backBuffer.Format));
            _bitmap1 = ToDispose(new Bitmap1(DeviceContext, _renderTarget2D));


            State = CanvasState.Refresh;
        }

        #endregion

        #region Private properties

        internal DeviceContext DeviceContext {
            get { return _service.DeviceContext; }
        }
        public DirectWrite.Factory DirectWriteFactory { get { return _service.DirectWriteFactory; } }
        private CanvasState State { get; set; }

        #endregion

        #region Public properties

        public Color ClearColor { get; set; }

        #endregion

        #region Public methods

        public void Clear() {
            State = CanvasState.Refresh;
            _objects.Clear();
        }

        public SolidColorBrush GetSolidColorBrush(Color color) {
            return ToDispose(new SolidColorBrush(DeviceContext, color));
        }

        public StrokeStyle GetStrokeStyle(StrokeStyleProperties strokeStyleProperties, float[] dashes) {
            throw new NotImplementedException();
            //if (dashes == null) throw new ArgumentNullException("dashes");
            //return ToDispose(new StrokeStyle(DeviceContext.Factory, strokeStyleProperties, dashes));
        }

        public StrokeStyle GetStrokeStyle(StrokeStyleProperties strokeStyleProperties) {
            return ToDispose(new StrokeStyle(DeviceContext.Factory, strokeStyleProperties));
        }

        public void PushObject(CanvasObject canvasObject) {
            if (canvasObject == null) throw new ArgumentNullException("canvasObject");
            bool isInitialized = canvasObject.IsInitialized;
            if (!isInitialized) {
                canvasObject.Initialize(DeviceContext);
            }
            _objects.Add(canvasObject);
            _queue.Enqueue(canvasObject);

            State = CanvasState.Append;
        }

        public void PushObjects(params CanvasObject[] canvasObjects) {
            throw new NotImplementedException();
            if (canvasObjects == null) throw new ArgumentNullException("canvasObjects");
            _objects.AddRange(canvasObjects);
        }

        public void Render() {
            if (_bitmap1 == null || _renderTarget2D == null) return;
            switch (State) {
                case CanvasState.Append:
                    DeviceContext.Target = _bitmap1;
                    using (DeviceContext.Target) {
                        DeviceContext.BeginDraw();
                        while (_queue.Count > 0) {
                            CanvasObject o = _queue.Dequeue();
                            o.DoWork(DeviceContext);
                        }
                        DeviceContext.EndDraw();
                    }
                    DeviceContext.Target = null;
                    State = CanvasState.Cache;
                    break;
                case CanvasState.Refresh:
                    DeviceContext.Target = _bitmap1;
                    using (DeviceContext.Target) {
                        DeviceContext.BeginDraw();
                        DeviceContext.Clear(ClearColor);
                        foreach (CanvasObject o in _objects) {
                            o.DoWork(DeviceContext);
                        }
                        DeviceContext.EndDraw();
                    }
                    DeviceContext.Target = null;
                    State = CanvasState.Cache;
                    break;
                case CanvasState.Cache:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _spriteBatch.Begin();
            _spriteBatch.Draw(_renderTarget2D, Vector2.Zero, Color.White);
            _spriteBatch.End();
        }

        #endregion
    }
}