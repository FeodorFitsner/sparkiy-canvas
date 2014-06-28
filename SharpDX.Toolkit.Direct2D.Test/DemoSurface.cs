using System;
using System.Collections.Generic;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.DXGI;

namespace SharpDX.Toolkit.Direct2D.Test {
    public class DemoSurface : Direct2DSurface {
        private Brush _fontBrush;
        private TextFormat _format;
        private SolidColorBrush _backgroundBrush;
        public string Text { get;  set; }

        public DemoSurface(IServiceProvider serviceProvider)
            : base(serviceProvider) {
        Text = "Demo text formatted by DirectWrite"
                    + " and drawn via Direct2D on a Direct3D 11.1 surface.";
 }

        protected override void LoadContent() {
            base.LoadContent();

            _fontBrush = ToDisposeContent(new SolidColorBrush(Direct2DService.DeviceContext, Color.White));
            _backgroundBrush = ToDisposeContent(new SolidColorBrush(Direct2DService.DeviceContext, new Color4(0,0,0,0.1f)));
            _format = ToDisposeContent(new TextFormat(Direct2DService.DirectWriteFactory, "Segoe UI", 15f));
        }

        protected override void Update(GameTime time) {
            base.Update(time);
            
            base.Redraw();
            
        }
        
        protected override void Draw() {
            base.Draw();


            if (Text != null) {
                RectangleF layoutRect = new RectangleF(20f, 20f, 250, 60);

                Direct2DService.DeviceContext.FillRectangle( layoutRect, _backgroundBrush);
                Direct2DService.DeviceContext.DrawText(Text, _format, layoutRect, _fontBrush);
            }
        }
    }


  
}