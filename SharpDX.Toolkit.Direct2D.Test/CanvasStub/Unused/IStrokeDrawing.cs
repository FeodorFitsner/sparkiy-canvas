using SharpDX.Direct2D1;

namespace SharpDX.Toolkit.Direct2D.Test.CanvasStub.Unused {
    internal interface IStrokeDrawing : IDrawing {
        StrokeStyle StrokeStyle { get; set; }
        float StrokeWidth { get; set; }
    }
}