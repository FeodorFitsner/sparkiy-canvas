// preliminary mock-up of a caching system for D2D
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SharpDX.Direct2D1;

namespace SharpDX.Toolkit {
    //http://msdn.microsoft.com/en-us/library/windows/desktop/dd756654(v=vs.85).aspx
    internal class CanvasTest {
        public CanvasTest() {
            var service = new Direct2DService(null);
            var canvas = new Canvas(service);
            var layer = canvas.GetLayer(LayerUsage.Static, 0);
            using (CanvasLayerContext ctx = layer.GetContext()) {

         //       service.DeviceContext.
            }
            canvas.Render();

            DeviceContext context = service.DeviceContext;
        }
    }

    public class Canvas {
        private readonly IDirect2DService _direct2DService;
        private readonly List<CanvasLayer> _layers;

        public Canvas(IDirect2DService direct2DService) {
            if (direct2DService == null) throw new ArgumentNullException("direct2DService");
            _direct2DService = direct2DService;
            _layers = new List<CanvasLayer>();
            Layers = new ReadOnlyCollection<CanvasLayer>(_layers);
        }

        private ReadOnlyCollection<CanvasLayer> Layers { get; set; }

        private bool IsDirty { get; set; }

        public void Render() {
        }

        public CanvasLayer GetLayer(LayerUsage usage, int zIndex) {
            var layer = new CanvasLayer(this, usage, zIndex);
            _layers.Add(layer);
            return layer;
        }
    }

    public class CanvasLayer {
        private readonly Canvas _canvas;
        private readonly int _zIndex;

        internal CanvasLayer(Canvas canvas, LayerUsage usage, int zIndex) {
            _canvas = canvas;
            _zIndex = zIndex;
            Usage = usage;
        }

        public LayerUsage Usage { get; private set; }

        private bool IsDirty { get; set; }

        public Canvas Canvas {
            get { return _canvas; }
        }

        private void Render() {
        }

        public CanvasLayerContext GetContext() {
            return new CanvasLayerContext(this);
        }
    }

    public class CanvasLayerContext : IDisposable {
        private readonly CanvasLayer _canvasLayer;

        public CanvasLayerContext(CanvasLayer canvasLayer) {
            _canvasLayer = canvasLayer;
        }

        public void Dispose() {
            throw new NotImplementedException();
        }
    }

    public enum LayerUsage {
        Static,
        Dynamic
    }
}