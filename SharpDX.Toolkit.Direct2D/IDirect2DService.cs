using System;
using SharpDX.Direct2D1;

namespace SharpDX.Toolkit.Direct2D
{
	/// <summary>
	/// Provides Direct2D support for drawing on D3D11.1 SwapChain
	/// </summary>
	public interface IDirect2DService : IDisposable
	{
		/// <summary>
		/// Gets a reference to the Direct2D device. Can be used to create additional <see cref="DeviceContext"/>.
		/// </summary>
		Device Device { get; }

		/// <summary>
		/// Gets a reference to the default <see cref="DeviceContext"/> which will draw directly over SwapChain.
		/// The developer is responsible to restore default render target states.
		/// </summary>
		DeviceContext Context { get; }

		/// <summary>
		/// Gets a reference to the default <see cref="SharpDX.DirectWrite.Factory1"/> used to create all DirectWrite objects.
		/// </summary>
		SharpDX.DirectWrite.Factory1 DwFactory { get; }
	}
}