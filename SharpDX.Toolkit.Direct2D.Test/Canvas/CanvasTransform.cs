using SharpDX.Direct2D1;

namespace SharpDX.Toolkit.Direct2D.Test.Canvas {
    public sealed class CanvasTransform : CanvasObject
    {
        public Matrix3x2 Transform { get; set; }

        public CanvasTransform(Matrix3x2 transform) {
            this.Transform = transform;
        }

        internal override void DoWork(DeviceContext context)
        {
            context.Transform = Transform;
            
        }

        internal override bool CanExecute() {
            throw new System.NotImplementedException();
        }

        public override string ToString() {
            return string.Format("Transform: {0}", Transform);
        }
    }
}