using System;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1;
using SharpDX.Toolkit.Graphics;

namespace SharpDX.Toolkit.Direct2D
{
    /// <summary>
    /// Provides Direct2D support for drawing on D3D11.1 SwapChain
    /// </summary>
    [ComVisible(false)]
    public sealed class Direct2DService : Component, IDirect2DService
	{
		// default debug level
		private const DebugLevel D2DDebugLevel = DebugLevel.Information;

		// a reference to service responsible for GraphicsDevice management
		private readonly IGraphicsDeviceService _graphicsDeviceService;

		private Device _device;	// D2D device
		private DeviceContext _deviceContext;  // Default D2D device context
		private SharpDX.DirectWrite.Factory1 _dwFactory; // DirectWrite factory

		/// <summary>
		/// Initializes a new instance of <see cref="Direct2DService"/>, subscribes to <see cref="GraphicsDevice"/> changes events via
		/// <see cref="IGraphicsDeviceService"/>.
		/// </summary>
		/// <param name="graphicsDeviceService">The service responsible for <see cref="GraphicsDevice"/> management.</param>
		/// <exception cref="ArgumentNullException">Then either <paramref name="graphicsDeviceService"/> is null.</exception>
		public Direct2DService(IGraphicsDeviceService graphicsDeviceService)
		{
			if (graphicsDeviceService == null) throw new ArgumentNullException("graphicsDeviceService");

			_graphicsDeviceService = graphicsDeviceService;

			graphicsDeviceService.DeviceCreated += HandleDeviceCreated;
			graphicsDeviceService.DeviceDisposing += HandleDeviceDisposing;
		}

		/// <summary>
		/// Gets a reference to the Direct2D device. Can be used to create additional <see cref="DeviceContext"/>.
		/// </summary>
		public Device Device { get { return _device; } }

		/// <summary>
		/// Gets a reference to the default <see cref="DeviceContext"/> which will draw directly over SwapChain.
		/// </summary>
		public DeviceContext Context { get { return _deviceContext; } }

		/// <summary>
		/// Gets a reference to the default <see cref="SharpDX.DirectWrite.Factory1"/> used to create all DirectWrite objects.
		/// </summary>
		public SharpDX.DirectWrite.Factory1 DwFactory { get { return _dwFactory; } }

        /// <summary>
        /// Diposes all resources associated with the current <see cref="Direct2DService"/> instance.
        /// </summary>
        /// <param name="disposeManagedResources">Indicates whether to dispose management resources.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_dwFactory")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_device")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_deviceContext")]
        protected override void Dispose(bool disposeManagedResources)
		{
			base.Dispose(disposeManagedResources);

			DisposeAll();
		}

		/// <summary>
		/// Handles the <see cref="IGraphicsDeviceService.DeviceCreated"/> event.
		/// Initializes the <see cref="Direct2DService.Device"/> and <see cref="Direct2DService.Context"/>.
		/// </summary>
		/// <param name="sender">Ignored.</param>
		/// <param name="e">Ignored.</param>
		private void HandleDeviceCreated(object sender, EventArgs e)
		{
			var d3D11Device = (SharpDX.Direct3D11.Device)_graphicsDeviceService.GraphicsDevice;

			using (var dxgiDevice = d3D11Device.QueryInterface<SharpDX.DXGI.Device>())
			{
				_device = new Device(dxgiDevice, new CreationProperties { DebugLevel = D2DDebugLevel });
				_deviceContext = new DeviceContext(_device, DeviceContextOptions.EnableMultithreadedOptimizations);
			}

			_dwFactory = new SharpDX.DirectWrite.Factory1();
		}

		/// <summary>
		/// Handles the <see cref="IGraphicsDeviceService.DeviceDisposing"/> event.
		/// Disposes the <see cref="Direct2DService.Device"/>, <see cref="Direct2DService.Context"/> and its render target associated with the current <see cref="Direct2DService"/> instance.
		/// </summary>
		/// <param name="sender">Ignored.</param>
		/// <param name="e">Ignored.</param>
		private void HandleDeviceDisposing(object sender, EventArgs e)
		{
			DisposeAll();
		}

		/// <summary>
		/// Disposes the <see cref="Direct2DService.Device"/>, <see cref="Direct2DService.Context"/> and its render target associated with the current <see cref="Direct2DService"/> instance.
		/// </summary>
		private void DisposeAll()
		{
			Utilities.Dispose(ref _deviceContext);
			Utilities.Dispose(ref _device);
			Utilities.Dispose(ref _dwFactory);
		}
	}
}