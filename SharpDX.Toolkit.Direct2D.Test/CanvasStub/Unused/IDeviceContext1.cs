using System;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.DXGI;
using Device = SharpDX.Direct2D1.Device;
using Factory = SharpDX.Direct2D1.Factory;
using TextAntialiasMode = SharpDX.Direct2D1.TextAntialiasMode;

namespace SharpDX.Toolkit.Direct2D.Test.CanvasStub.Unused {
    public interface IDeviceContext1 {
        /// <summary>
        ///     <p>Gets the device associated with a device context.</p>
        /// </summary>
        /// <remarks>
        ///     <p>
        ///         The application can retrieve the device even if it is created from an earlier render target code-path. The
        ///         application must use an
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.DeviceContext" />
        ///         </strong>
        ///         interface and then call <strong>GetDevice</strong>. Some functionality for controlling all of the resources for
        ///         a set of device contexts is maintained only on an
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.Device" />
        ///         </strong>
        ///         object.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1DeviceContext::GetDevice']/*" />
        /// <msdn-id>hh404513</msdn-id>
        /// <unmanaged>GetDevice</unmanaged>
        /// <unmanaged-short>GetDevice</unmanaged-short>
        /// <unmanaged>void ID2D1DeviceContext::GetDevice([Out] ID2D1Device** device)</unmanaged>
        Device Device { get; }

        /// <summary>
        ///     <p>Gets or sets the target currently associated with the device context.</p>
        /// </summary>
        /// <remarks>
        ///     <p>
        ///         If a target is not associated with the device context, <em>target</em> will contain
        ///         <strong>
        ///             <c>null</c>
        ///         </strong>
        ///         when the methods returns.
        ///     </p>
        ///     <p>
        ///         If the currently selected target is a bitmap rather than a command list, the application can gain access to the
        ///         initial bitmaps created by using one of the following methods:
        ///     </p>
        ///     <ul>
        ///         <li>
        ///             <strong>CreateHwndRenderTarget</strong>
        ///         </li>
        ///         <li>
        ///             <strong>CreateDxgiSurfaceRenderTarget</strong>
        ///         </li>
        ///         <li>
        ///             <strong>CreateWicBitmapRenderTarget</strong>
        ///         </li>
        ///         <li>
        ///             <strong>CreateDCRenderTarget</strong>
        ///         </li>
        ///         <li>
        ///             <strong>CreateCompatibleRenderTarget</strong>
        ///         </li>
        ///     </ul>
        ///     <p>
        ///         It is not possible for an application to destroy these bitmaps.  All of these bitmaps are bindable as bitmap
        ///         targets.  However not all of these bitmaps can be used as bitmap sources for
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget" />
        ///         </strong>
        ///         methods.
        ///     </p>
        ///     <p>
        ///         <strong>CreateDxgiSurfaceRenderTarget</strong> will create a bitmap that is usable as a bitmap source if the
        ///         DXGI surface is bindable as a shader resource view.
        ///     </p>
        ///     <p> <strong>CreateCompatibleRenderTarget</strong> will always create bitmaps that are usable as a bitmap source.</p>
        ///     <p>
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.BeginDraw" />
        ///         </strong>
        ///         will copy from the <see cref="System.IntPtr" /> to the original bitmap associated with it.
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         will copy from the original bitmap to the <see cref="System.IntPtr" />.
        ///     </p>
        ///     <p>
        ///         <strong>
        ///             <see cref="SharpDX.WIC.Bitmap" />
        ///         </strong>
        ///         objects will be locked in the following circumstances:
        ///     </p>
        ///     <ul>
        ///         <li>BeginDraw has been called and the currently selected target bitmap is a WIC bitmap.</li>
        ///         <li>
        ///             A WIC bitmap is set as the target of a device context after BeginDraw has been called and before EndDraw
        ///             has been called.
        ///         </li>
        ///         <li>Any of the ID2D1Bitmap::Copy* methods are called with a WIC bitmap as either the source or destination.</li>
        ///     </ul>
        ///     <p><see cref="SharpDX.WIC.Bitmap" /> objects will be unlocked in the following circumstances:</p>
        ///     <ul>
        ///         <li>EndDraw is called and the currently selected target bitmap is a WIC bitmap.</li>
        ///         <li>A WIC bitmap is removed as the target of a device context between the calls to BeginDraw and EndDraw.</li>
        ///         <li>Any of the ID2D1Bitmap::Copy* methods are called with a WIC bitmap as either the source or destination.</li>
        ///     </ul>
        ///     <p>Direct2D will only lock bitmaps that are not currently locked.</p>
        ///     <p>
        ///         Calling <strong>QueryInterface</strong> for <strong>ID2D1GdiInteropRenderTarget</strong> will always succeed.
        ///         <strong>ID2D1GdiInteropRenderTarget::GetDC</strong> will return a device context corresponding to the currently
        ///         bound target bitmap.  GetDC will fail if the target bitmap was not created with the GDI_COMPATIBLE flag set.
        ///     </p>
        ///     <p>
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.WindowRenderTarget.Resize" />
        ///         </strong>
        ///         will return
        ///         <strong>
        ///             <see cref="SharpDX.DXGI.ResultCode.InvalidCall" />
        ///         </strong>
        ///         if there are any outstanding references to the original target bitmap associated with the render target.
        ///     </p>
        ///     <p>
        ///         Although the target can be a command list, it cannot be any other type of image. It cannot be the output image
        ///         of an effect.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1DeviceContext::GetTarget']/*" />
        /// <msdn-id>hh404523</msdn-id>
        /// <unmanaged>GetTarget / SetTarget</unmanaged>
        /// <unmanaged-short>GetTarget</unmanaged-short>
        /// <unmanaged>void ID2D1DeviceContext::GetTarget([Out, Optional] ID2D1Image** image)</unmanaged>
        Image Target { get; set; }

        /// <summary>
        ///     <p>Gets or sets the rendering controls that have been applied to the context.</p>
        /// </summary>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext::GetRenderingControls']/*" />
        /// <msdn-id>hh404519</msdn-id>
        /// <unmanaged>GetRenderingControls / SetRenderingControls</unmanaged>
        /// <unmanaged-short>GetRenderingControls</unmanaged-short>
        /// <unmanaged>void ID2D1DeviceContext::GetRenderingControls([Out] D2D1_RENDERING_CONTROLS* renderingControls)</unmanaged>
        RenderingControls RenderingControls { get; set; }

        /// <summary>
        ///     <p>Returns or sets the currently set primitive blend used by the device context.  </p>
        /// </summary>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext::GetPrimitiveBlend']/*" />
        /// <msdn-id>hh404517</msdn-id>
        /// <unmanaged>GetPrimitiveBlend / SetPrimitiveBlend</unmanaged>
        /// <unmanaged-short>GetPrimitiveBlend</unmanaged-short>
        /// <unmanaged>D2D1_PRIMITIVE_BLEND ID2D1DeviceContext::GetPrimitiveBlend()</unmanaged>
        PrimitiveBlend PrimitiveBlend { get; set; }

        /// <summary>
        ///     <p>Gets or sets the mode that  is being used to interpret values by the device context.</p>
        /// </summary>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1DeviceContext::GetUnitMode']/*" />
        /// <msdn-id>hh404525</msdn-id>
        /// <unmanaged>GetUnitMode / SetUnitMode</unmanaged>
        /// <unmanaged-short>GetUnitMode</unmanaged-short>
        /// <unmanaged>D2D1_UNIT_MODE ID2D1DeviceContext::GetUnitMode()</unmanaged>
        UnitMode UnitMode { get; set; }

        /// <summary>
        ///     <p>Gets or sets the current transform of the render target. </p>
        /// </summary>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::GetTransform']/*" />
        /// <msdn-id>dd316845</msdn-id>
        /// <unmanaged>GetTransform / SetTransform</unmanaged>
        /// <unmanaged-short>GetTransform</unmanaged-short>
        /// <unmanaged>void ID2D1RenderTarget::GetTransform([Out] D2D_MATRIX_3X2_F* transform)</unmanaged>
        Matrix3x2 Transform { get; set; }

        /// <summary>
        ///     <p>Retrieves or sets the current antialiasing mode for nontext drawing operations.</p>
        /// </summary>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::GetAntialiasMode']/*" />
        /// <msdn-id>dd316805</msdn-id>
        /// <unmanaged>GetAntialiasMode / SetAntialiasMode</unmanaged>
        /// <unmanaged-short>GetAntialiasMode</unmanaged-short>
        /// <unmanaged>D2D1_ANTIALIAS_MODE ID2D1RenderTarget::GetAntialiasMode()</unmanaged>
        AntialiasMode AntialiasMode { get; set; }

        /// <summary>
        ///     <p>Gets or sets the current antialiasing mode for text and glyph drawing operations. </p>
        /// </summary>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::GetTextAntialiasMode']/*" />
        /// <msdn-id>dd316835</msdn-id>
        /// <unmanaged>GetTextAntialiasMode / SetTextAntialiasMode</unmanaged>
        /// <unmanaged-short>GetTextAntialiasMode</unmanaged-short>
        /// <unmanaged>D2D1_TEXT_ANTIALIAS_MODE ID2D1RenderTarget::GetTextAntialiasMode()</unmanaged>
        TextAntialiasMode TextAntialiasMode { get; set; }

        /// <summary>
        ///     <p>Retrieves or sets the render target's current text rendering options. </p>
        /// </summary>
        /// <remarks>
        ///     <p>
        ///         If the settings specified by  <em>textRenderingParams</em> are incompatible with the render target's text
        ///         antialiasing mode (specified by <strong>SetTextAntialiasMode</strong>), subsequent text and glyph drawing
        ///         operations will fail and put the render target into an error state.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::GetTextRenderingParams']/*" />
        /// <msdn-id>dd316841</msdn-id>
        /// <unmanaged>GetTextRenderingParams / SetTextRenderingParams</unmanaged>
        /// <unmanaged-short>GetTextRenderingParams</unmanaged-short>
        /// <unmanaged>void ID2D1RenderTarget::GetTextRenderingParams([Out, Optional] IDWriteRenderingParams** textRenderingParams)</unmanaged>
        RenderingParams TextRenderingParams { get; set; }

        /// <summary>
        ///     <p>Retrieves the pixel format and alpha mode of the render target. </p>
        /// </summary>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::GetPixelFormat']/*" />
        /// <msdn-id>dd316814</msdn-id>
        /// <unmanaged>GetPixelFormat</unmanaged>
        /// <unmanaged-short>GetPixelFormat</unmanaged-short>
        /// <unmanaged>D2D1_PIXEL_FORMAT ID2D1RenderTarget::GetPixelFormat()</unmanaged>
        PixelFormat PixelFormat { get; }

        /// <summary>
        ///     <p>Returns the size of the render target in device-independent pixels.</p>
        /// </summary>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::GetSize']/*" />
        /// <msdn-id>dd316823</msdn-id>
        /// <unmanaged>GetSize</unmanaged>
        /// <unmanaged-short>GetSize</unmanaged-short>
        /// <unmanaged>D2D_SIZE_F ID2D1RenderTarget::GetSize()</unmanaged>
        Size2F Size { get; }

        /// <summary>
        ///     <p>Returns the size of the render target in device pixels.</p>
        /// </summary>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::GetPixelSize']/*" />
        /// <msdn-id>dd316820</msdn-id>
        /// <unmanaged>GetPixelSize</unmanaged>
        /// <unmanaged-short>GetPixelSize</unmanaged-short>
        /// <unmanaged>D2D_SIZE_U ID2D1RenderTarget::GetPixelSize()</unmanaged>
        Size2 PixelSize { get; }

        /// <summary>
        ///     <p>
        ///         Gets the maximum size, in device-dependent units (pixels), of  any one bitmap dimension supported by the render
        ///         target.
        ///     </p>
        /// </summary>
        /// <remarks>
        ///     <p>This method returns the maximum texture size of the Direct3D device.</p>
        ///     <p>
        ///         <strong>Note</strong>??The software renderer and WARP devices return the value of 16 megapixels (16*1024*1024).
        ///         You can create a Direct2D texture that is this size, but not a Direct3D texture that is this size.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::GetMaximumBitmapSize']/*" />
        /// <msdn-id>dd742853</msdn-id>
        /// <unmanaged>GetMaximumBitmapSize</unmanaged>
        /// <unmanaged-short>GetMaximumBitmapSize</unmanaged-short>
        /// <unmanaged>unsigned int ID2D1RenderTarget::GetMaximumBitmapSize()</unmanaged>
        int MaximumBitmapSize { get; }

        /// <summary>
        ///     Get or set the default stroke width used for all methods that are not explicitly using it. Default is set to 1.0f.
        /// </summary>
        float StrokeWidth { get; set; }

        /// <summary>
        ///     Get or sets the dots per inch (DPI) of the render target.
        /// </summary>
        /// <remarks>
        ///     This method specifies the mapping from pixel space to device-independent space  for the render target.  If both
        ///     dpiX and dpiY are 0, the factory-read system DPI is chosen. If one parameter is zero and the other unspecified, the
        ///     DPI is not changed. For <see cref="WindowRenderTarget" />, the DPI defaults to the most recently factory-read
        ///     system DPI. The default value for all other render targets is 96 DPI.
        /// </remarks>
        /// <unmanaged>void ID2D1RenderTarget::SetDpi([None] float dpiX,[None] float dpiY)</unmanaged>
        Size2F DotsPerInch { get; set; }

        /// <summary>
        ///     <p>Retrieves the factory associated with this resource.</p>
        /// </summary>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1Resource::GetFactory']/*" />
        /// <msdn-id>dd316911</msdn-id>
        /// <unmanaged>GetFactory</unmanaged>
        /// <unmanaged-short>GetFactory</unmanaged-short>
        /// <unmanaged>void ID2D1Resource::GetFactory([Out] ID2D1Factory** factory)</unmanaged>
        Factory Factory { get; }

        /// <summary>
        ///     Gets or sets a custom user tag object to associate with this instance..
        /// </summary>
        /// <value>The tag object.</value>
        object Tag { get; set; }

        /// <summary>
        ///     Get a pointer to the underlying Cpp Object
        /// </summary>
        IntPtr NativePointer { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        bool IsDisposed { get; }

        /// <summary>
        ///     <p>Renders a given geometry realization to the target with the specified brush.</p>
        /// </summary>
        /// <param name="geometryRealization">
        ///     <dd>
        ///         <p>The geometry realization to be rendered.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush to render the realization with.</p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         This method respects all currently set state (transform, DPI, unit mode, target image, clips, layers); however,
        ///         artifacts such as faceting may appear when rendering the realizations with a large effective scale (either via
        ///         the transform or the DPI). Callers should create their realizations with an appropriate flattening tolerance
        ///         using either <strong>D2D1_DEFAULT_FLATTENING_TOLERANCE</strong> or <strong>ComputeFlatteningTolerance</strong>
        ///         to compensate for this.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext1::DrawGeometryRealization']/*" />
        /// <msdn-id>dn280464</msdn-id>
        /// <unmanaged>
        ///     void ID2D1DeviceContext1::DrawGeometryRealization([In] ID2D1GeometryRealization* geometryRealization,[In]
        ///     ID2D1Brush* brush)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext1::DrawGeometryRealization</unmanaged-short>
        void DrawGeometryRealization(GeometryRealization geometryRealization, Brush brush);

        /// <summary>
        ///     <p>
        ///         Indicates whether the format is supported by the device context.  The formats supported are usually determined
        ///         by the underlying hardware.
        ///     </p>
        /// </summary>
        /// <param name="format">
        ///     <dd>
        ///         <p>The DXGI format to check.</p>
        ///     </dd>
        /// </param>
        /// <returns>
        ///     <p>
        ///         Returns TRUE if the format is supported.  Returns <see cref="SharpDX.Result.False" /> if the format is not
        ///         supported.
        ///     </p>
        /// </returns>
        /// <remarks>
        ///     <p>
        ///         You can use supported formats in the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.PixelFormat" />
        ///         </strong>
        ///         structure to create bitmaps and render targets. Direct2D doesn't support all DXGI formats, even though they may
        ///         have some level of Direct3D support by the hardware.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext::IsDxgiFormatSupported']/*" />
        /// <msdn-id>hh847982</msdn-id>
        /// <unmanaged>BOOL ID2D1DeviceContext::IsDxgiFormatSupported([In] DXGI_FORMAT format)</unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::IsDxgiFormatSupported</unmanaged-short>
        Bool IsDxgiFormatSupported(Format format);

        /// <summary>
        ///     <p>Indicates whether the buffer precision is supported by the underlying Direct3D <strong>device.</strong> </p>
        /// </summary>
        /// <param name="bufferPrecision">No documentation.</param>
        /// <returns>
        ///     <p>
        ///         Returns TRUE if the buffer precision is supported.  Returns <see cref="SharpDX.Result.False" /> if the buffer
        ///         precision is not supported.
        ///     </p>
        /// </returns>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext::IsBufferPrecisionSupported']/*" />
        /// <msdn-id>dn441541</msdn-id>
        /// <unmanaged>BOOL ID2D1DeviceContext::IsBufferPrecisionSupported([In] D2D1_BUFFER_PRECISION bufferPrecision)</unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::IsBufferPrecisionSupported</unmanaged-short>
        Bool IsBufferPrecisionSupported(BufferPrecision bufferPrecision);

        /// <summary>
        ///     <p>Gets the local bounds of an image.</p>
        /// </summary>
        /// <param name="image">
        ///     <dd>
        ///         <p>The image whose bounds will be calculated.</p>
        ///     </dd>
        /// </param>
        /// <returns>
        ///     <dd>
        ///         <p>
        ///             When this method returns, contains a reference to the bounds of the image in device independent pixels
        ///             (DIPs) and in local space.
        ///         </p>
        ///     </dd>
        /// </returns>
        /// <remarks>
        ///     <p>
        ///         The image bounds don't include multiplication by the world transform.  They do reflect the current DPI, unit
        ///         mode, and interpolation mode of the context.  To get the bounds that include the world trasnfrom, use
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.DeviceContext.GetImageWorldBounds" />
        ///         </strong>
        ///         .
        ///     </p>
        ///     <p>
        ///         The returned bounds reflect which pixels would be impacted by calling <strong>DrawImage</strong> with a target
        ///         offset of (0,0) and an identity world transform matrix.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext::GetImageLocalBounds']/*" />
        /// <msdn-id>hh404515</msdn-id>
        /// <unmanaged>HRESULT ID2D1DeviceContext::GetImageLocalBounds([In] ID2D1Image* image,[Out] D2D_RECT_F* localBounds)</unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::GetImageLocalBounds</unmanaged-short>
        RectangleF GetImageLocalBounds(Image image);

        /// <summary>
        ///     <p>Gets the world bounds of an image.</p>
        /// </summary>
        /// <param name="image">
        ///     <dd>
        ///         <p>The image whose bounds will be calculated.</p>
        ///     </dd>
        /// </param>
        /// <returns>
        ///     <dd>
        ///         <p>
        ///             When this method returns, contains a reference to the bounds of the image in device independent pixels
        ///             (DIPs).
        ///         </p>
        ///     </dd>
        /// </returns>
        /// <remarks>
        ///     <p>
        ///         The image bounds reflect the current DPI, unit mode, and world transform of the context.  To get bounds which
        ///         don't include the world transform, use
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.DeviceContext.GetImageLocalBounds" />
        ///         </strong>
        ///         .
        ///     </p>
        ///     <p>
        ///         The returned bounds reflect which pixels would be impacted by calling <strong>DrawImage</strong> with the same
        ///         image and a target offset of (0,0).  They do not reflect the current clip rectangle set on the device context
        ///         or the extent of the context?s current target image.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext::GetImageWorldBounds']/*" />
        /// <msdn-id>hh847979</msdn-id>
        /// <unmanaged>HRESULT ID2D1DeviceContext::GetImageWorldBounds([In] ID2D1Image* image,[Out] D2D_RECT_F* worldBounds)</unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::GetImageWorldBounds</unmanaged-short>
        RectangleF GetImageWorldBounds(Image image);

        /// <summary>
        ///     <p> Gets the world-space bounds in DIPs of the glyph run using the device context DPI. </p>
        /// </summary>
        /// <param name="baselineOrigin">
        ///     <dd>
        ///         <p>The origin of the baseline for the glyph run.</p>
        ///     </dd>
        /// </param>
        /// <param name="glyphRun">
        ///     <dd>
        ///         <p>The glyph run to render.</p>
        ///     </dd>
        /// </param>
        /// <param name="measuringMode">
        ///     <dd>
        ///         <p>
        ///             The DirectWrite measuring mode that indicates how glyph metrics are used to measure text when it is
        ///             formatted.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <returns>
        ///     <dd>
        ///         <p>The bounds of the glyph run in DIPs and in world space.</p>
        ///     </dd>
        /// </returns>
        /// <remarks>
        ///     <p>The image bounds reflect the current DPI, unit mode, and world transform of the context. </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext::GetGlyphRunWorldBounds']/*" />
        /// <msdn-id>hh847978</msdn-id>
        /// <unmanaged>
        ///     HRESULT ID2D1DeviceContext::GetGlyphRunWorldBounds([In] D2D_POINT_2F baselineOrigin,[In] const
        ///     DWRITE_GLYPH_RUN* glyphRun,[In] DWRITE_MEASURING_MODE measuringMode,[Out] D2D_RECT_F* bounds)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::GetGlyphRunWorldBounds</unmanaged-short>
        RectangleF GetGlyphRunWorldBounds(Vector2 baselineOrigin, GlyphRun glyphRun, MeasuringMode measuringMode);

        /// <summary>
        ///     <p>Draws a series of glyphs to the device context.</p>
        /// </summary>
        /// <param name="baselineOrigin">
        ///     <dd>
        ///         <p>Origin of first glyph in the series.</p>
        ///     </dd>
        /// </param>
        /// <param name="glyphRun">
        ///     <dd>
        ///         <p>Glyph information including glyph indices, advances, and offsets.</p>
        ///     </dd>
        /// </param>
        /// <param name="glyphRunDescription">
        ///     <dd>
        ///         <p>Supplementary glyph series information.</p>
        ///     </dd>
        /// </param>
        /// <param name="foregroundBrush">
        ///     <dd>
        ///         <p>The brush that defines the text color.</p>
        ///     </dd>
        /// </param>
        /// <param name="measuringMode">
        ///     <dd>
        ///         <p>
        ///             The measuring mode of the glyph series, used to determine the advances and offsets. The default value is
        ///             <see cref="SharpDX.Direct2D1.MeasuringMode.Natural" />.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         The <em>glyphRunDescription</em> is ignored when rendering, but can be useful for printing and serialization of
        ///         rendering commands, such as to an XPS or SVG file. This extends
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.DrawGlyphRun" />
        ///         </strong>
        ///         , which lacked the glyph run description.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1DeviceContext::DrawGlyphRun']/*" />
        /// <msdn-id>hh404508</msdn-id>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawGlyphRun([In] D2D_POINT_2F baselineOrigin,[In] const DWRITE_GLYPH_RUN*
        ///     glyphRun,[In, Optional] const DWRITE_GLYPH_RUN_DESCRIPTION* glyphRunDescription,[In] ID2D1Brush*
        ///     foregroundBrush,[In] DWRITE_MEASURING_MODE measuringMode)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::DrawGlyphRun</unmanaged-short>
        void DrawGlyphRun(Vector2 baselineOrigin, GlyphRun glyphRun, GlyphRunDescription glyphRunDescription,
            Brush foregroundBrush, MeasuringMode measuringMode);

        /// <summary>
        ///     <p>Draws an image to the device context.</p>
        /// </summary>
        /// <param name="image">
        ///     <dd>
        ///         <p>The image to be drawn to the device context.</p>
        ///     </dd>
        /// </param>
        /// <param name="targetOffset">
        ///     <dd>
        ///         <p>
        ///             The  offset in the destination space that the image will be rendered to. The entire logical extent of the
        ///             image will be rendered to the corresponding destination. If not specified, the destination origin will be
        ///             (0, 0). The top-left corner of the image will be mapped to the target offset. This will not necessarily be
        ///             the origin. This default value is
        ///             <em>
        ///                 <c>null</c>
        ///             </em>
        ///             .
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="imageRectangle">
        ///     <dd>
        ///         <p>
        ///             The corresponding rectangle in the image space will be mapped to the given origins when processing the
        ///             image. This default value is
        ///             <em>
        ///                 <c>null</c>
        ///             </em>
        ///             .
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="interpolationMode">
        ///     <dd>
        ///         <p>
        ///             The interpolation mode that will be used to scale the image if necessary. The default value is
        ///             <strong>D2D1_IMAGE_INTERPOLATION_BILINEAR</strong>.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="compositeMode">
        ///     <dd>
        ///         <p>
        ///             The composite mode that will be applied to the limits of the currently selected clip. The default value is
        ///             <strong>D2D1_COMPOSITE_MODE_DEFAULT</strong>
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         If <em>interpolationMode</em> is <strong>D2D1_INTERPOLATION_MODE_HIGH_QUALITY</strong>, different scalers will
        ///         be used depending on the scale factor implied by the world transform.
        ///     </p>
        ///     <p>
        ///         Any invalid rectangles accumulated on any effect that is drawn by this call will be discarded regardless of
        ///         which portion of the image rectangle is drawn.
        ///     </p>
        ///     <p>
        ///         If <em>compositeMode</em> is <strong>D2D1_COMPOSITE_MODE_DEFAULT</strong>, <strong>DrawImage</strong> will use
        ///         the currently selected primitive blend specified by
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.DeviceContext.SetPrimitiveBlend" />
        ///         </strong>
        ///         . If <em>compositeMode</em> is not <strong>D2D1_COMPOSITE_MODE_DEFAULT</strong>, the image will be extended to
        ///         transparent up to the current axis-aligned clip.
        ///     </p>
        ///     <p>
        ///         If there is an image rectangle and a world transform, this is equivalent to inserting a clip effect to represent
        ///         the image rectangle and a 2D affine transform to take into account the world transform.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1DeviceContext::DrawImage']/*" />
        /// <msdn-id>hh404511</msdn-id>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawImage([In] ID2D1Image* image,[In, Optional] const D2D_POINT_2F*
        ///     targetOffset,[In, Optional] const D2D_RECT_F* imageRectangle,[In] D2D1_INTERPOLATION_MODE interpolationMode,[In]
        ///     D2D1_COMPOSITE_MODE compositeMode)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::DrawImage</unmanaged-short>
        void DrawImage(Image image, Vector2? targetOffset, RectangleF? imageRectangle,
            InterpolationMode interpolationMode, CompositeMode compositeMode);

        /// <summary>
        ///     <p>Draw a metafile to the device context.</p>
        /// </summary>
        /// <param name="gdiMetafile">
        ///     <dd>
        ///         <p>The metafile to draw.</p>
        ///     </dd>
        /// </param>
        /// <param name="targetOffset">
        ///     <dd>
        ///         <p>The offset from the upper left corner of the render target.</p>
        ///     </dd>
        /// </param>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext::DrawGdiMetafile']/*" />
        /// <msdn-id>jj841147</msdn-id>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawGdiMetafile([In] ID2D1GdiMetafile* gdiMetafile,[In, Optional] const
        ///     D2D_POINT_2F* targetOffset)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::DrawGdiMetafile</unmanaged-short>
        void DrawGdiMetafile(GdiMetafile gdiMetafile, Vector2? targetOffset);

        /// <summary>
        ///     <p>Draws a bitmap to the render target.</p>
        /// </summary>
        /// <param name="bitmap">
        ///     <dd>
        ///         <p>The bitmap to draw.</p>
        ///     </dd>
        /// </param>
        /// <param name="destinationRectangle">
        ///     <dd>
        ///         <p>
        ///             The destination rectangle. The default is the size of the bitmap and the location is the upper left corner
        ///             of the render target.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="opacity">
        ///     <dd>
        ///         <p>The opacity of the bitmap.</p>
        ///     </dd>
        /// </param>
        /// <param name="interpolationMode">
        ///     <dd>
        ///         <p>The interpolation mode to use.</p>
        ///     </dd>
        /// </param>
        /// <param name="sourceRectangle">
        ///     <dd>
        ///         <p>An optional source rectangle.</p>
        ///     </dd>
        /// </param>
        /// <param name="erspectiveTransformRef">
        ///     <dd>
        ///         <p>An optional perspective transform.</p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         The destinationRectangle parameter defines the rectangle in the target where the bitmap will appear (in
        ///         device-independent pixels (DIPs)).  This is affected by the currently set transform and the perspective
        ///         transform, if set.  If <c>null</c> is specified, then the destination rectangle is (left=0, top=0, right =
        ///         width(sourceRectangle), bottom = height(sourceRectangle)).
        ///     </p>
        ///     <p>
        ///         The <em>sourceRectangle</em> parameter defines the sub-rectangle of the source bitmap (in DIPs).
        ///         <strong>DrawBitmap</strong> will clip this rectangle to the size of the source bitmap, thus making it
        ///         impossible to sample outside of the bitmap.  If <c>null</c> is specified, then the source rectangle is taken to
        ///         be the size of the source bitmap.
        ///     </p>
        ///     <p>
        ///         If you specify <em>perspectiveTransform</em> it is applied to the rect in addition to the transform set on the
        ///         render target.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1DeviceContext::DrawBitmap']/*" />
        /// <msdn-id>jj841144</msdn-id>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawBitmap([In] ID2D1Bitmap* bitmap,[In, Optional] const D2D_RECT_F*
        ///     destinationRectangle,[In] float opacity,[In] D2D1_INTERPOLATION_MODE interpolationMode,[In, Optional] const
        ///     D2D_RECT_F* sourceRectangle,[In, Optional] const D2D_MATRIX_4X4_F* perspectiveTransform)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::DrawBitmap</unmanaged-short>
        void DrawBitmap(Bitmap bitmap, RectangleF? destinationRectangle, float opacity,
            InterpolationMode interpolationMode, RectangleF? sourceRectangle, Matrix? erspectiveTransformRef);

        /// <summary>
        ///     <p>Push a layer onto the clip and layer stack of the device context.</p>
        /// </summary>
        /// <param name="layerParameters">
        ///     <dd>
        ///         <p>The parameters that defines the layer.</p>
        ///     </dd>
        /// </param>
        /// <param name="layer">
        ///     <dd>
        ///         <p>The layer resource to push on the device context that receives subsequent drawing operations. </p>
        ///         <p><strong>Note</strong>??If a layer is not specified, Direct2D manages the layer resource automatically.</p>
        ///     </dd>
        /// </param>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1DeviceContext::PushLayer']/*" />
        /// <msdn-id>hh847983</msdn-id>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::PushLayer([In] const D2D1_LAYER_PARAMETERS1* layerParameters,[In, Optional]
        ///     ID2D1Layer* layer)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::PushLayer</unmanaged-short>
        void PushLayer(ref LayerParameters1 layerParameters, Layer layer);

        /// <summary>
        ///     <p>This indicates that a portion of an effect's input is invalid. This method can be called many times.</p>
        ///     <p>
        ///         You can use this method to propagate invalid rectangles through an effect graph. You can query Direct2D using
        ///         the <strong>GetEffectInvalidRectangles</strong> method.
        ///     </p>
        ///     <p>
        ///         <strong>Note</strong>??Direct2D does not automatically use these invalid rectangles to reduce the region of an
        ///         effect that is rendered.
        ///     </p>
        ///     <p>
        ///         You can also use this method to invalidate caches that have accumulated while rendering effects that have the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.Property.Cached" />
        ///         </strong>
        ///         property set to true.
        ///     </p>
        /// </summary>
        /// <param name="effect">No documentation.</param>
        /// <param name="input">No documentation.</param>
        /// <param name="inputRectangle">No documentation.</param>
        /// <returns>
        ///     <p>
        ///         The method returns an
        ///         <strong>
        ///             <see cref="SharpDX.Result" />
        ///         </strong>
        ///         . Possible values include, but are not limited to, those in the following table.
        ///     </p>
        ///     <table>
        ///         <tr>
        ///             <th>
        ///                 <see cref="SharpDX.Result" />
        ///             </th>
        ///             <th>Description</th>
        ///         </tr>
        ///         <tr>
        ///             <td>
        ///                 <see cref="SharpDX.Result.Ok" />
        ///             </td>
        ///             <td>No error occurred.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>E_OUTOFMEMORY</td><td>Direct2D could not allocate sufficient memory to complete the call.</td>
        ///         </tr>
        ///         <tr>
        ///             <td>E_INVALIDARG</td><td>An invalid parameter was passed to the returning function.</td>
        ///         </tr>
        ///     </table>
        ///     <p>?</p>
        /// </returns>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext::InvalidateEffectInputRectangle']/*" />
        /// <msdn-id>hh847980</msdn-id>
        /// <unmanaged>
        ///     HRESULT ID2D1DeviceContext::InvalidateEffectInputRectangle([In] ID2D1Effect* effect,[In] unsigned int
        ///     input,[In] const D2D_RECT_F* inputRectangle)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::InvalidateEffectInputRectangle</unmanaged-short>
        void InvalidateEffectInputRectangle(Effect effect, int input, RectangleF inputRectangle);

        /// <summary>
        ///     <p>
        ///         Fill using the alpha channel of the supplied opacity mask bitmap. The brush opacity will be modulated by the
        ///         mask. The render target antialiasing mode must be set to aliased.
        ///     </p>
        /// </summary>
        /// <param name="opacityMask">
        ///     <dd>
        ///         <p>The bitmap that acts as the opacity mask</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush to use for filling the primitive.</p>
        ///     </dd>
        /// </param>
        /// <param name="destinationRectangle">
        ///     <dd>
        ///         <p>The destination rectangle to output to in the render target</p>
        ///     </dd>
        /// </param>
        /// <param name="sourceRectangle">
        ///     <dd>
        ///         <p>The source rectangle from the opacity mask bitmap.</p>
        ///     </dd>
        /// </param>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1DeviceContext::FillOpacityMask']/*" />
        /// <msdn-id>hh847974</msdn-id>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::FillOpacityMask([In] ID2D1Bitmap* opacityMask,[In] ID2D1Brush* brush,[In, Optional]
        ///     const D2D_RECT_F* destinationRectangle,[In, Optional] const D2D_RECT_F* sourceRectangle)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1DeviceContext::FillOpacityMask</unmanaged-short>
        void FillOpacityMask(Bitmap opacityMask, Brush brush, RectangleF? destinationRectangle,
            RectangleF? sourceRectangle);

        /// <summary>
        ///     No documentation.
        /// </summary>
        /// <param name="effect">No documentation.</param>
        /// <param name="targetOffset">No documentation.</param>
        /// <param name="interpolationMode">No documentation.</param>
        /// <param name="compositeMode">No documentation.</param>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawImage([In] ID2D1Image* image,[In, Optional] const D2D_POINT_2F*
        ///     targetOffset,[In, Optional] const D2D_RECT_F* imageRectangle,[In] D2D1_INTERPOLATION_MODE interpolationMode,[In]
        ///     D2D1_COMPOSITE_MODE compositeMode)
        /// </unmanaged>
        void DrawImage(Effect effect, Vector2 targetOffset,
            InterpolationMode interpolationMode = InterpolationMode.Linear,
            CompositeMode compositeMode = CompositeMode.SourceOver);

        /// <summary>
        ///     No documentation.
        /// </summary>
        /// <param name="effect">No documentation.</param>
        /// <param name="interpolationMode">No documentation.</param>
        /// <param name="compositeMode">No documentation.</param>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawImage([In] ID2D1Image* image,[In, Optional] const D2D_POINT_2F*
        ///     targetOffset,[In, Optional] const D2D_RECT_F* imageRectangle,[In] D2D1_INTERPOLATION_MODE interpolationMode,[In]
        ///     D2D1_COMPOSITE_MODE compositeMode)
        /// </unmanaged>
        void DrawImage(Effect effect, InterpolationMode interpolationMode = InterpolationMode.Linear,
            CompositeMode compositeMode = CompositeMode.SourceOver);

        /// <summary>
        ///     No documentation.
        /// </summary>
        /// <param name="image">No documentation.</param>
        /// <param name="targetOffset">No documentation.</param>
        /// <param name="interpolationMode">No documentation.</param>
        /// <param name="compositeMode">No documentation.</param>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawImage([In] ID2D1Image* image,[In, Optional] const D2D_POINT_2F*
        ///     targetOffset,[In, Optional] const D2D_RECT_F* imageRectangle,[In] D2D1_INTERPOLATION_MODE interpolationMode,[In]
        ///     D2D1_COMPOSITE_MODE compositeMode)
        /// </unmanaged>
        void DrawImage(Image image, Vector2 targetOffset, InterpolationMode interpolationMode = InterpolationMode.Linear,
            CompositeMode compositeMode = CompositeMode.SourceOver);

        /// <summary>
        ///     No documentation.
        /// </summary>
        /// <param name="image">No documentation.</param>
        /// <param name="interpolationMode">No documentation.</param>
        /// <param name="compositeMode">No documentation.</param>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawImage([In] ID2D1Image* image,[In, Optional] const D2D_POINT_2F*
        ///     targetOffset,[In, Optional] const D2D_RECT_F* imageRectangle,[In] D2D1_INTERPOLATION_MODE interpolationMode,[In]
        ///     D2D1_COMPOSITE_MODE compositeMode)
        /// </unmanaged>
        void DrawImage(Image image, InterpolationMode interpolationMode = InterpolationMode.Linear,
            CompositeMode compositeMode = CompositeMode.SourceOver);

        /// <summary>
        ///     Draws the bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="opacity">The opacity.</param>
        /// <param name="interpolationMode">The interpolation mode.</param>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawBitmap([In] ID2D1Bitmap* bitmap,[In, Optional] const D2D_RECT_F*
        ///     destinationRectangle,[In] float opacity,[In] D2D1_INTERPOLATION_MODE interpolationMode,[In, Optional] const
        ///     D2D_RECT_F* sourceRectangle,[In, Optional] const D2D_MATRIX_4X4_F* perspectiveTransform)
        /// </unmanaged>
        void DrawBitmap(Bitmap bitmap, float opacity, InterpolationMode interpolationMode);

        /// <summary>
        ///     Draws the bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="opacity">The opacity.</param>
        /// <param name="interpolationMode">The interpolation mode.</param>
        /// <param name="perspectiveTransformRef">The perspective transform ref.</param>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawBitmap([In] ID2D1Bitmap* bitmap,[In, Optional] const D2D_RECT_F*
        ///     destinationRectangle,[In] float opacity,[In] D2D1_INTERPOLATION_MODE interpolationMode,[In, Optional] const
        ///     D2D_RECT_F* sourceRectangle,[In, Optional] const D2D_MATRIX_4X4_F* perspectiveTransform)
        /// </unmanaged>
        void DrawBitmap(Bitmap bitmap, float opacity, InterpolationMode interpolationMode,
            Matrix perspectiveTransformRef);

        /// <summary>
        ///     Draws the bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="opacity">The opacity.</param>
        /// <param name="interpolationMode">The interpolation mode.</param>
        /// <param name="sourceRectangle">The source rectangle.</param>
        /// <param name="perspectiveTransformRef">The perspective transform ref.</param>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::DrawBitmap([In] ID2D1Bitmap* bitmap,[In, Optional] const D2D_RECT_F*
        ///     destinationRectangle,[In] float opacity,[In] D2D1_INTERPOLATION_MODE interpolationMode,[In, Optional] const
        ///     D2D_RECT_F* sourceRectangle,[In, Optional] const D2D_MATRIX_4X4_F* perspectiveTransform)
        /// </unmanaged>
        void DrawBitmap(Bitmap bitmap, float opacity, InterpolationMode interpolationMode, RectangleF sourceRectangle,
            Matrix perspectiveTransformRef);

        /// <summary>
        ///     No documentation.
        /// </summary>
        /// <param name="layerParameters">No documentation.</param>
        /// <param name="layer">No documentation.</param>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::PushLayer([In] const D2D1_LAYER_PARAMETERS1* layerParameters,[In, Optional]
        ///     ID2D1Layer* layer)
        /// </unmanaged>
        void PushLayer(LayerParameters1 layerParameters, Layer layer);

        /// <summary>
        ///     Gets the effect invalid rectangles.
        /// </summary>
        /// <param name="effect">The effect.</param>
        /// <returns></returns>
        /// <unmanaged>
        ///     HRESULT ID2D1DeviceContext::GetEffectInvalidRectangles([In] ID2D1Effect* effect,[Out, Buffer] D2D_RECT_F*
        ///     rectangles,[In] unsigned int rectanglesCount)
        /// </unmanaged>
        RectangleF[] GetEffectInvalidRectangles(Effect effect);

        /// <summary>
        ///     Gets the effect required input rectangles.
        /// </summary>
        /// <param name="renderEffect">The render effect.</param>
        /// <param name="inputDescriptions">The input descriptions.</param>
        /// <returns></returns>
        /// <unmanaged>
        ///     HRESULT ID2D1DeviceContext::GetEffectRequiredInputRectangles([In] ID2D1Effect* renderEffect,[In, Optional]
        ///     const D2D_RECT_F* renderImageRectangle,[In, Buffer] const D2D1_EFFECT_INPUT_DESCRIPTION* inputDescriptions,[Out,
        ///     Buffer] D2D_RECT_F* requiredInputRects,[In] unsigned int inputCount)
        /// </unmanaged>
        RectangleF[] GetEffectRequiredInputRectangles(Effect renderEffect, EffectInputDescription[] inputDescriptions);

        /// <summary>
        ///     Gets the effect required input rectangles.
        /// </summary>
        /// <param name="renderEffect">The render effect.</param>
        /// <param name="renderImageRectangle">The render image rectangle.</param>
        /// <param name="inputDescriptions">The input descriptions.</param>
        /// <returns></returns>
        /// <unmanaged>
        ///     HRESULT ID2D1DeviceContext::GetEffectRequiredInputRectangles([In] ID2D1Effect* renderEffect,[In, Optional]
        ///     const D2D_RECT_F* renderImageRectangle,[In, Buffer] const D2D1_EFFECT_INPUT_DESCRIPTION* inputDescriptions,[Out,
        ///     Buffer] D2D_RECT_F* requiredInputRects,[In] unsigned int inputCount)
        /// </unmanaged>
        RectangleF[] GetEffectRequiredInputRectangles(Effect renderEffect, RectangleF renderImageRectangle,
            EffectInputDescription[] inputDescriptions);

        /// <summary>
        ///     No documentation.
        /// </summary>
        /// <param name="opacityMask">No documentation.</param>
        /// <param name="brush">No documentation.</param>
        /// <unmanaged>
        ///     void ID2D1DeviceContext::FillOpacityMask([In] ID2D1Bitmap* opacityMask,[In] ID2D1Brush* brush,[In, Optional]
        ///     const D2D_RECT_F* destinationRectangle,[In, Optional] const D2D_RECT_F* sourceRectangle)
        /// </unmanaged>
        void FillOpacityMask(Bitmap opacityMask, Brush brush);

        /// <summary>
        ///     <p>Draws a line between the specified points using the specified stroke style. </p>
        /// </summary>
        /// <param name="point0">
        ///     <dd>
        ///         <p>The start point of the line, in device-independent pixels.</p>
        ///     </dd>
        /// </param>
        /// <param name="point1">
        ///     <dd>
        ///         <p>The end point of the line, in device-independent pixels.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush used to paint the line's stroke.</p>
        ///     </dd>
        /// </param>
        /// <param name="strokeWidth">
        ///     <dd>
        ///         <p>
        ///             The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If
        ///             this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="strokeStyle">
        ///     <dd>
        ///         <p>
        ///             The style of stroke to paint, or
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             to paint a solid line.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>DrawLine</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::DrawLine']/*" />
        /// <msdn-id>dd371895</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawLine([In] D2D_POINT_2F point0,[In] D2D_POINT_2F point1,[In] ID2D1Brush*
        ///     brush,[In] float strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::DrawLine</unmanaged-short>
        void DrawLine(Vector2 point0, Vector2 point1, Brush brush, float strokeWidth, StrokeStyle strokeStyle);

        /// <summary>
        ///     <p>Draws the outline of a rectangle that has the specified dimensions and stroke style. </p>
        /// </summary>
        /// <param name="rect">
        ///     <dd>
        ///         <p>The dimensions of the rectangle to draw, in device-independent pixels.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush used to paint the rectangle's stroke.</p>
        ///     </dd>
        /// </param>
        /// <param name="strokeWidth">
        ///     <dd>
        ///         <p>
        ///             The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If
        ///             this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="strokeStyle">
        ///     <dd>
        ///         <p>
        ///             The style of stroke to paint, or
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             to paint a solid stroke.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         When this method fails, it does not return an error code. To determine whether a drawing method (such as
        ///         <strong>DrawRectangle</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         method.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::DrawRectangle']/*" />
        /// <msdn-id>dd371902</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawRectangle([In] const D2D_RECT_F* rect,[In] ID2D1Brush* brush,[In] float
        ///     strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::DrawRectangle</unmanaged-short>
        void DrawRectangle(RectangleF rect, Brush brush, float strokeWidth, StrokeStyle strokeStyle);

        /// <summary>
        ///     <p>Paints the interior of the specified rectangle. </p>
        /// </summary>
        /// <param name="rect">
        ///     <dd>
        ///         <p>The dimension of the rectangle to paint, in device-independent pixels.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush used to paint the rectangle's interior.</p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>FillRectangle</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::FillRectangle']/*" />
        /// <msdn-id>dd371954</msdn-id>
        /// <unmanaged>void ID2D1RenderTarget::FillRectangle([In] const D2D_RECT_F* rect,[In] ID2D1Brush* brush)</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::FillRectangle</unmanaged-short>
        void FillRectangle(RectangleF rect, Brush brush);

        /// <summary>
        ///     <p> Draws the outline of the specified rounded rectangle using the specified stroke style.</p>
        /// </summary>
        /// <param name="roundedRect">
        ///     <dd>
        ///         <p>The dimensions of the rounded rectangle to draw, in device-independent pixels.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush used to paint the rounded rectangle's outline. </p>
        ///     </dd>
        /// </param>
        /// <param name="strokeWidth">
        ///     <dd>
        ///         <p>
        ///             The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If
        ///             this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="strokeStyle">
        ///     <dd>
        ///         <p>
        ///             The style of the rounded rectangle's stroke, or
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             to paint a solid stroke. The default value is
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             .
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>DrawRoundedRectangle</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::DrawRoundedRectangle']/*" />
        /// <msdn-id>dd371908</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawRoundedRectangle([In] const D2D1_ROUNDED_RECT* roundedRect,[In] ID2D1Brush*
        ///     brush,[In] float strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::DrawRoundedRectangle</unmanaged-short>
        void DrawRoundedRectangle(ref RoundedRectangle roundedRect, Brush brush, float strokeWidth,
            StrokeStyle strokeStyle);

        /// <summary>
        ///     <p>Paints the interior of the specified rounded rectangle. </p>
        /// </summary>
        /// <param name="roundedRect">
        ///     <dd>
        ///         <p>The dimensions of the rounded rectangle to paint, in device independent pixels.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush used to paint the interior of the rounded rectangle.</p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>FillRoundedRectangle</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::FillRoundedRectangle']/*" />
        /// <msdn-id>dd316795</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::FillRoundedRectangle([In] const D2D1_ROUNDED_RECT* roundedRect,[In] ID2D1Brush*
        ///     brush)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::FillRoundedRectangle</unmanaged-short>
        void FillRoundedRectangle(ref RoundedRectangle roundedRect, Brush brush);

        /// <summary>
        ///     <p>Draws the outline of the specified ellipse using the specified stroke style. </p>
        /// </summary>
        /// <param name="ellipse">
        ///     <dd>
        ///         <p>The position and radius of the ellipse to draw, in device-independent pixels.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush used to paint the ellipse's outline.</p>
        ///     </dd>
        /// </param>
        /// <param name="strokeWidth">
        ///     <dd>
        ///         <p>
        ///             The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If
        ///             this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="strokeStyle">
        ///     <dd>
        ///         <p>
        ///             The style of stroke to apply to the ellipse's outline, or
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             to paint a solid stroke.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         The <strong>DrawEllipse</strong> method doesn't return an error code if it fails. To determine whether a
        ///         drawing operation (such as <strong>DrawEllipse</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::DrawEllipse']/*" />
        /// <msdn-id>dd371886</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawEllipse([In] const D2D1_ELLIPSE* ellipse,[In] ID2D1Brush* brush,[In] float
        ///     strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::DrawEllipse</unmanaged-short>
        void DrawEllipse(Ellipse ellipse, Brush brush, float strokeWidth, StrokeStyle strokeStyle);

        /// <summary>
        ///     <p>Paints the interior of the specified ellipse. </p>
        /// </summary>
        /// <param name="ellipse">
        ///     <dd>
        ///         <p>The position and radius, in device-independent pixels, of the ellipse to paint.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush used to paint the interior of the ellipse.</p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>FillEllipse</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::FillEllipse']/*" />
        /// <msdn-id>dd371928</msdn-id>
        /// <unmanaged>void ID2D1RenderTarget::FillEllipse([In] const D2D1_ELLIPSE* ellipse,[In] ID2D1Brush* brush)</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::FillEllipse</unmanaged-short>
        void FillEllipse(Ellipse ellipse, Brush brush);

        /// <summary>
        ///     <p>Draws the outline of the specified geometry using the specified stroke style. </p>
        /// </summary>
        /// <param name="geometry">
        ///     <dd>
        ///         <p>The geometry to draw.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush used to paint the geometry's stroke.</p>
        ///     </dd>
        /// </param>
        /// <param name="strokeWidth">
        ///     <dd>
        ///         <p>
        ///             The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If
        ///             this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="strokeStyle">
        ///     <dd>
        ///         <p>
        ///             The style of stroke to apply to the geometry's outline, or
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             to paint a solid stroke.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>DrawGeometry</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::DrawGeometry']/*" />
        /// <msdn-id>dd371890</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawGeometry([In] ID2D1Geometry* geometry,[In] ID2D1Brush* brush,[In] float
        ///     strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::DrawGeometry</unmanaged-short>
        void DrawGeometry(Geometry geometry, Brush brush, float strokeWidth, StrokeStyle strokeStyle);

        /// <summary>
        ///     <p>Paints the interior of the specified geometry. </p>
        /// </summary>
        /// <param name="geometry">
        ///     <dd>
        ///         <p>The geometry to paint.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush used to paint the geometry's interior.</p>
        ///     </dd>
        /// </param>
        /// <param name="opacityBrush">
        ///     <dd>
        ///         <p>
        ///             The opacity mask to apply to the geometry, or
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             for no opacity mask. If an opacity mask (the <em>opacityBrush</em> parameter) is specified, <em>brush</em>
        ///             must be an
        ///             <strong>
        ///                 <see cref="SharpDX.Direct2D1.BitmapBrush" />
        ///             </strong>
        ///             that has   its x- and y-extend modes set to
        ///             <strong>
        ///                 <see cref="SharpDX.Direct2D1.ExtendMode.Clamp" />
        ///             </strong>
        ///             . For more information, see the Remarks section.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         If the <em>opacityBrush</em> parameter is not
        ///         <strong>
        ///             <c>null</c>
        ///         </strong>
        ///         , the alpha value of each pixel of the mapped <em>opacityBrush</em> is used to determine the resulting opacity
        ///         of each corresponding pixel of the geometry. Only the alpha value of each color in the brush is used for this
        ///         processing; all other color information is ignored.  The alpha value specified by the brush is multiplied by
        ///         the alpha value of the geometry after the geometry has been painted by <em>brush</em>.
        ///     </p>
        ///     <p>
        ///         When this method fails, it does not return an error code. To determine whether a drawing operation (such as
        ///         <strong>FillGeometry</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         method.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::FillGeometry']/*" />
        /// <msdn-id>dd371933</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::FillGeometry([In] ID2D1Geometry* geometry,[In] ID2D1Brush* brush,[In, Optional]
        ///     ID2D1Brush* opacityBrush)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::FillGeometry</unmanaged-short>
        void FillGeometry(Geometry geometry, Brush brush, Brush opacityBrush);

        /// <summary>
        ///     <p> Paints the interior of the specified mesh.</p>
        /// </summary>
        /// <param name="mesh">
        ///     <dd>
        ///         <p>The mesh to paint.</p>
        ///     </dd>
        /// </param>
        /// <param name="brush">
        ///     <dd>
        ///         <p>The brush used to paint the mesh.</p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         The current antialias mode of the render target must be
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.AntialiasMode.Aliased" />
        ///         </strong>
        ///         when <strong>FillMesh</strong> is called. To change the render target's antialias mode, use the
        ///         <strong>SetAntialiasMode</strong> method.
        ///     </p>
        ///     <p>
        ///         <strong>FillMesh</strong> does not expect a particular winding order for the triangles in the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.Mesh" />
        ///         </strong>
        ///         ; both clockwise and counter-clockwise will work.
        ///     </p>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>FillMesh</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::FillMesh']/*" />
        /// <msdn-id>dd371939</msdn-id>
        /// <unmanaged>void ID2D1RenderTarget::FillMesh([In] ID2D1Mesh* mesh,[In] ID2D1Brush* brush)</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::FillMesh</unmanaged-short>
        void FillMesh(Mesh mesh, Brush brush);

        /// <summary>
        ///     Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the
        ///     render target.
        /// </summary>
        /// <param name="opacityMask">No documentation.</param>
        /// <param name="brush">No documentation.</param>
        /// <param name="content">No documentation.</param>
        /// <param name="destinationRectangle">No documentation.</param>
        /// <param name="sourceRectangle">No documentation.</param>
        /// <remarks>
        ///     <p>
        ///         For this method to work properly, the render target must be using the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.AntialiasMode.Aliased" />
        ///         </strong>
        ///         antialiasing mode. You can set the antialiasing mode by calling the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.SetAntialiasMode" />
        ///         </strong>
        ///         method.
        ///     </p>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>FillOpacityMask</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::FillOpacityMask']/*" />
        /// <msdn-id>dd742850</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::FillOpacityMask([In] ID2D1Bitmap* opacityMask,[In] ID2D1Brush* brush,[In]
        ///     D2D1_OPACITY_MASK_CONTENT content,[In, Optional] const D2D_RECT_F* destinationRectangle,[In, Optional] const
        ///     D2D_RECT_F* sourceRectangle)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::FillOpacityMask</unmanaged-short>
        void FillOpacityMask(Bitmap opacityMask, Brush brush, OpacityMaskContent content,
            RectangleF? destinationRectangle, RectangleF? sourceRectangle);

        /// <summary>
        ///     <p>Draws the specified bitmap after scaling it to the size of the specified rectangle. </p>
        /// </summary>
        /// <param name="bitmap">
        ///     <dd>
        ///         <p>The bitmap to render.</p>
        ///     </dd>
        /// </param>
        /// <param name="destinationRectangle">
        ///     <dd>
        ///         <p>
        ///             The size and position, in device-independent pixels in the render target's coordinate space, of the area to
        ///             which the bitmap is drawn. If the rectangle is not well-ordered, nothing is drawn, but the render target
        ///             does not enter an error state.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="opacity">
        ///     <dd>
        ///         <p>
        ///             A value between 0.0f and 1.0f, inclusive, that specifies the opacity value to be applied to the bitmap; this
        ///             value is multiplied against the alpha values of the bitmap's contents.  Default is 1.0f.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="interpolationMode">
        ///     <dd>
        ///         <p>
        ///             The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation. The default
        ///             value is
        ///             <strong>
        ///                 <see cref="SharpDX.Direct2D1.BitmapInterpolationMode.Linear" />
        ///             </strong>
        ///             .
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="sourceRectangle">
        ///     <dd>
        ///         <p>
        ///             The size and position, in device-independent pixels in the bitmap's coordinate space, of the area within
        ///             the bitmap to draw;
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             to draw the entire bitmap.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>DrawBitmap</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::DrawBitmap']/*" />
        /// <msdn-id>dd371878</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawBitmap([In] ID2D1Bitmap* bitmap,[In, Optional] const D2D_RECT_F*
        ///     destinationRectangle,[In] float opacity,[In] D2D1_BITMAP_INTERPOLATION_MODE interpolationMode,[In, Optional] const
        ///     D2D_RECT_F* sourceRectangle)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::DrawBitmap</unmanaged-short>
        void DrawBitmap(Bitmap bitmap, RectangleF? destinationRectangle, float opacity,
            BitmapInterpolationMode interpolationMode, RectangleF? sourceRectangle);

        /// <summary>
        ///     <p>
        ///         Draws the specified text using the format information provided by an
        ///         <strong>
        ///             <see cref="SharpDX.DirectWrite.TextFormat" />
        ///         </strong>
        ///         object.
        ///     </p>
        /// </summary>
        /// <param name="text">No documentation.</param>
        /// <param name="stringLength">No documentation.</param>
        /// <param name="textFormat">No documentation.</param>
        /// <param name="layoutRect">No documentation.</param>
        /// <param name="defaultForegroundBrush">No documentation.</param>
        /// <param name="options">No documentation.</param>
        /// <param name="measuringMode">No documentation.</param>
        /// <remarks>
        ///     <p>
        ///         To create an
        ///         <strong>
        ///             <see cref="SharpDX.DirectWrite.TextFormat" />
        ///         </strong>
        ///         object, create an
        ///         <strong>
        ///             <see cref="SharpDX.DirectWrite.Factory" />
        ///         </strong>
        ///         and call its <strong>CreateTextFormat</strong> method.
        ///     </p>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>DrawText</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::DrawText']/*" />
        /// <msdn-id>dd371919</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawText([In, Buffer] const wchar_t* string,[In] unsigned int stringLength,[In]
        ///     IDWriteTextFormat* textFormat,[In] const D2D_RECT_F* layoutRect,[In] ID2D1Brush* defaultForegroundBrush,[In]
        ///     D2D1_DRAW_TEXT_OPTIONS options,[In] DWRITE_MEASURING_MODE measuringMode)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::DrawText</unmanaged-short>
        void DrawText(string text, int stringLength, TextFormat textFormat, RectangleF layoutRect,
            Brush defaultForegroundBrush, DrawTextOptions options, MeasuringMode measuringMode);

        /// <summary>
        ///     <p>
        ///         Draws the formatted text described by the specified
        ///         <strong>
        ///             <see cref="SharpDX.DirectWrite.TextLayout" />
        ///         </strong>
        ///         object.
        ///     </p>
        /// </summary>
        /// <param name="origin">No documentation.</param>
        /// <param name="textLayout">No documentation.</param>
        /// <param name="defaultForegroundBrush">No documentation.</param>
        /// <param name="options">No documentation.</param>
        /// <remarks>
        ///     <p>
        ///         When drawing the same text repeatedly, using the <strong>DrawTextLayout</strong> method is more efficient than
        ///         using the <strong>DrawText</strong> method because the text doesn't need to be formatted and the layout
        ///         processed with each call.
        ///     </p>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>DrawTextLayout</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::DrawTextLayout']/*" />
        /// <msdn-id>dd371913</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawTextLayout([In] D2D_POINT_2F origin,[In] IDWriteTextLayout* textLayout,[In]
        ///     ID2D1Brush* defaultForegroundBrush,[In] D2D1_DRAW_TEXT_OPTIONS options)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::DrawTextLayout</unmanaged-short>
        void DrawTextLayout(Vector2 origin, TextLayout textLayout, Brush defaultForegroundBrush, DrawTextOptions options);

        /// <summary>
        ///     <p>Draws the specified glyphs. </p>
        /// </summary>
        /// <param name="baselineOrigin">
        ///     <dd>
        ///         <p>The origin, in device-independent pixels, of the glyphs' baseline.</p>
        ///     </dd>
        /// </param>
        /// <param name="glyphRun">
        ///     <dd>
        ///         <p>The glyphs to render.</p>
        ///     </dd>
        /// </param>
        /// <param name="foregroundBrush">
        ///     <dd>
        ///         <p>The brush used to paint the specified glyphs.</p>
        ///     </dd>
        /// </param>
        /// <param name="measuringMode">
        ///     <dd>
        ///         <p>
        ///             A value that indicates how glyph metrics are used to measure text when it is formatted.  The default value
        ///             is
        ///             <strong>
        ///                 <see cref="SharpDX.Direct2D1.MeasuringMode.Natural" />
        ///             </strong>
        ///             .
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>DrawGlyphRun</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::DrawGlyphRun']/*" />
        /// <msdn-id>dd371893</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawGlyphRun([In] D2D_POINT_2F baselineOrigin,[In] const DWRITE_GLYPH_RUN*
        ///     glyphRun,[In] ID2D1Brush* foregroundBrush,[In] DWRITE_MEASURING_MODE measuringMode)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::DrawGlyphRun</unmanaged-short>
        void DrawGlyphRun(Vector2 baselineOrigin, GlyphRun glyphRun, Brush foregroundBrush, MeasuringMode measuringMode);

        /// <summary>
        ///     <p>Specifies a label for subsequent drawing operations.   </p>
        /// </summary>
        /// <param name="tag1">
        ///     <dd>
        ///         <p>A label to apply to subsequent drawing operations.</p>
        ///     </dd>
        /// </param>
        /// <param name="tag2">
        ///     <dd>
        ///         <p>A label to apply to subsequent drawing operations.</p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         The labels specified by this method are printed by debug error messages. If no tag is set, the default value for
        ///         each tag is 0.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::SetTags']/*" />
        /// <msdn-id>dd316892</msdn-id>
        /// <unmanaged>void ID2D1RenderTarget::SetTags([In] unsigned longlong tag1,[In] unsigned longlong tag2)</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::SetTags</unmanaged-short>
        void SetTags(long tag1, long tag2);

        /// <summary>
        ///     <p>Gets the label for subsequent drawing operations. </p>
        /// </summary>
        /// <param name="tag1">
        ///     <dd>
        ///         <p>
        ///             When this method returns, contains the first label for subsequent drawing operations. This parameter is
        ///             passed uninitialized. If
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             is specified, no value is retrieved for this parameter.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="tag2">
        ///     <dd>
        ///         <p>
        ///             When this method returns, contains the second label for subsequent drawing operations. This parameter is
        ///             passed uninitialized. If
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             is specified, no value is retrieved for this parameter.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>If the same address is passed for both parameters, both parameters receive the value of the second tag. </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::GetTags']/*" />
        /// <msdn-id>dd316830</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::GetTags([Out, Optional] unsigned longlong* tag1,[Out, Optional] unsigned longlong*
        ///     tag2)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::GetTags</unmanaged-short>
        void GetTags(out long tag1, out long tag2);

        /// <summary>
        ///     <p>
        ///         Adds the specified layer to the render target so that it receives all subsequent drawing operations until
        ///         <strong>PopLayer</strong> is called.
        ///     </p>
        /// </summary>
        /// <param name="layerParameters">No documentation.</param>
        /// <param name="layer">No documentation.</param>
        /// <remarks>
        ///     <p>
        ///         The <strong>PushLayer</strong> method allows a caller to begin redirecting rendering to a layer. All rendering
        ///         operations are valid in a layer. The location of the layer is affected by the world transform set on the render
        ///         target.
        ///     </p>
        ///     <p>
        ///         Each <strong>PushLayer</strong> must have a matching <strong>PopLayer</strong> call. If there are more
        ///         <strong>PopLayer</strong> calls than <strong>PushLayer</strong> calls, the render target is placed into an
        ///         error state. If <strong>Flush</strong> is called before all outstanding layers are popped, the render target is
        ///         placed into an error state, and an error is returned. The error state can be cleared by a call to
        ///         <strong>EndDraw</strong>.
        ///     </p>
        ///     <p>
        ///         A particular
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.Layer" />
        ///         </strong>
        ///         resource can be active only at one time. In other words, you cannot call a <strong>PushLayer</strong> method,
        ///         and then immediately follow  with another <strong>PushLayer</strong> method with the same layer resource.
        ///         Instead, you must call the second <strong>PushLayer</strong> method with different layer resources.
        ///     </p>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>PushLayer</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::PushLayer']/*" />
        /// <msdn-id>dd316869</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::PushLayer([In] const D2D1_LAYER_PARAMETERS* layerParameters,[In, Optional]
        ///     ID2D1Layer* layer)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::PushLayer</unmanaged-short>
        void PushLayer(ref LayerParameters layerParameters, Layer layer);

        /// <summary>
        ///     <p>Stops redirecting drawing operations to the layer that is specified by the last <strong>PushLayer</strong> call. </p>
        /// </summary>
        /// <remarks>
        ///     <p>A <strong>PopLayer</strong> must match a previous <strong>PushLayer</strong> call.</p>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>PopLayer</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::PopLayer']/*" />
        /// <msdn-id>dd316852</msdn-id>
        /// <unmanaged>void ID2D1RenderTarget::PopLayer()</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::PopLayer</unmanaged-short>
        void PopLayer();

        /// <summary>
        ///     <p>Executes all pending drawing commands. </p>
        /// </summary>
        /// <param name="tag1">
        ///     <dd>
        ///         <p>
        ///             When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no
        ///             errors. This parameter is passed uninitialized.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="tag2">
        ///     <dd>
        ///         <p>
        ///             When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no
        ///             errors. This parameter is passed uninitialized.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <returns>
        ///     <p>
        ///         If the method succeeds, it returns
        ///         <strong>
        ///             <see cref="SharpDX.Result.Ok" />
        ///         </strong>
        ///         . Otherwise, it returns an
        ///         <strong>
        ///             <see cref="SharpDX.Result" />
        ///         </strong>
        ///         error code and sets <em>tag1</em> and <em>tag2</em> to the tags that were active when the error occurred. If no
        ///         error occurred, this method sets the error tag state to be (0,0).
        ///     </p>
        /// </returns>
        /// <remarks>
        ///     <p>This command does not flush the device that is associated with the render target.  </p>
        ///     <p>Calling this method resets the error state of the render target.</p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::Flush']/*" />
        /// <msdn-id>dd316801</msdn-id>
        /// <unmanaged>
        ///     HRESULT ID2D1RenderTarget::Flush([Out, Optional] unsigned longlong* tag1,[Out, Optional] unsigned longlong*
        ///     tag2)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::Flush</unmanaged-short>
        void Flush(out long tag1, out long tag2);

        /// <summary>
        ///     <p>
        ///         Saves the current drawing state to the specified
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.DrawingStateBlock" />
        ///         </strong>
        ///         .
        ///     </p>
        /// </summary>
        /// <param name="drawingStateBlock">No documentation.</param>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::SaveDrawingState']/*" />
        /// <msdn-id>dd316876</msdn-id>
        /// <unmanaged>void ID2D1RenderTarget::SaveDrawingState([InOut] ID2D1DrawingStateBlock* drawingStateBlock)</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::SaveDrawingState</unmanaged-short>
        void SaveDrawingState(DrawingStateBlock drawingStateBlock);

        /// <summary>
        ///     <p>
        ///         Sets the render target's drawing state to that of the specified
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.DrawingStateBlock" />
        ///         </strong>
        ///         .
        ///     </p>
        /// </summary>
        /// <param name="drawingStateBlock">No documentation.</param>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::RestoreDrawingState']/*" />
        /// <msdn-id>dd316872</msdn-id>
        /// <unmanaged>void ID2D1RenderTarget::RestoreDrawingState([In] ID2D1DrawingStateBlock* drawingStateBlock)</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::RestoreDrawingState</unmanaged-short>
        void RestoreDrawingState(DrawingStateBlock drawingStateBlock);

        /// <summary>
        ///     <p>Specifies a rectangle to which all subsequent drawing operations are clipped. </p>
        /// </summary>
        /// <param name="clipRect">
        ///     <dd>
        ///         <p>The size and position of the clipping area, in device-independent pixels.</p>
        ///     </dd>
        /// </param>
        /// <param name="antialiasMode">
        ///     <dd>
        ///         <p>
        ///             The antialiasing mode that is used to draw the edges of clip rects that have subpixel boundaries, and to
        ///             blend the clip with the scene contents. The blending is performed once when the
        ///             <strong>PopAxisAlignedClip</strong> method is called, and does not apply to each primitive within the
        ///             layer.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         The <em>clipRect</em> is transformed by the current world transform set on the render target. After the
        ///         transform is applied to the <em>clipRect</em> that is passed in, the axis-aligned bounding box for the
        ///         <em>clipRect</em> is computed.  For efficiency, the contents are clipped to this axis-aligned bounding box and
        ///         not to the original <em>clipRect</em> that is passed in.
        ///     </p>
        ///     <p>
        ///         The following diagrams show how a rotation transform is applied to the render target, the resulting
        ///         <em>clipRect</em>, and  a calculated axis-aligned bounding box.
        ///     </p>
        ///     <ol>
        ///         <li>
        ///             <p>
        ///                 Assume the rectangle in the following illustration is a render target that is aligned to the screen
        ///                 pixels.
        ///             </p>
        ///             <p></p>
        ///         </li>
        ///         <li>
        ///             <p>
        ///                 Apply a rotation transform to the render target. In the following illustration, the black rectangle
        ///                 represents the original render target and the red dashed rectangle represents the transformed render
        ///                 target.
        ///             </p>
        ///             <p></p>
        ///         </li>
        ///         <li>
        ///             <p>
        ///                 After calling <strong>PushAxisAlignedClip</strong>, the rotation transform is applied to the
        ///                 <em>clipRect</em>. In the following illustration, the blue rectangle represents the transformed
        ///                 <em>clipRect</em>.
        ///             </p>
        ///             <p></p>
        ///         </li>
        ///         <li>
        ///             <p>
        ///                 The axis-aligned bounding box is calculated. The green dashed rectangle represents the bounding box in
        ///                 the following illustration. All contents are clipped to this axis-aligned bounding box.
        ///             </p>
        ///             <p></p>
        ///         </li>
        ///     </ol>
        ///     <p>
        ///         <strong>Note</strong>??If rendering operations fail or if <strong>PopAxisAlignedClip</strong> is not called,
        ///         clip rects may cause some artifacts on the render target. <strong>PopAxisAlignedClip</strong> can be considered
        ///         a drawing operation that is designed to fix the borders of a clipping region. Without this call, the borders of
        ///         a clipped area may be not antialiased or otherwise corrected.
        ///     </p>
        ///     <p>
        ///         The <strong>PushAxisAlignedClip</strong> and <strong>PopAxisAlignedClip</strong> must match. Otherwise, the
        ///         error state is set. For the render target to continue receiving new commands, you can call
        ///         <strong>Flush</strong> to clear the error.
        ///     </p>
        ///     <p>
        ///         A           <strong>PushAxisAlignedClip</strong> and <strong>PopAxisAlignedClip</strong> pair can occur around
        ///         or within a PushLayer and PopLayer, but cannot overlap. For example, the sequence of
        ///         <strong>PushAxisAlignedClip</strong>, <strong>PushLayer</strong>, <strong>PopLayer</strong>,
        ///         <strong>PopAxisAlignedClip</strong> is valid, but the sequence of <strong>PushAxisAlignedClip</strong>,
        ///         <strong>PushLayer</strong>, <strong>PopAxisAlignedClip</strong>, <strong>PopLayer</strong> is invalid.
        ///     </p>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>PushAxisAlignedClip</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::PushAxisAlignedClip']/*" />
        /// <msdn-id>dd316860</msdn-id>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::PushAxisAlignedClip([In] const D2D_RECT_F* clipRect,[In] D2D1_ANTIALIAS_MODE
        ///     antialiasMode)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::PushAxisAlignedClip</unmanaged-short>
        void PushAxisAlignedClip(RectangleF clipRect, AntialiasMode antialiasMode);

        /// <summary>
        ///     <p>
        ///         Removes the last axis-aligned clip from the render target. After this method is called, the clip is no longer
        ///         applied to subsequent drawing operations.
        ///     </p>
        /// </summary>
        /// <remarks>
        ///     <p>
        ///         A <strong>PushAxisAlignedClip</strong>/<strong>PopAxisAlignedClip</strong> pair can occur around or within a
        ///         <strong>PushLayer</strong>/<strong>PopLayer</strong> pair, but may not overlap. For example, a
        ///         <strong>PushAxisAlignedClip</strong>, <strong>PushLayer</strong>, <strong>PopLayer</strong>,
        ///         <strong>PopAxisAlignedClip</strong> sequence is valid, but a <strong>PushAxisAlignedClip</strong>,
        ///         <strong>PushLayer</strong>, <strong>PopAxisAlignedClip</strong>, <strong>PopLayer</strong> sequence is not.
        ///     </p>
        ///     <p><strong>PopAxisAlignedClip</strong> must be called once for every call to <strong>PushAxisAlignedClip</strong>.</p>
        ///     <p>For an example, see How to Clip with an Axis-Aligned Clip Rectangle.</p>
        ///     <p>
        ///         This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///         <strong>PopAxisAlignedClip</strong>) failed, check the result returned by the
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.EndDraw" />
        ///         </strong>
        ///         or
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget.Flush" />
        ///         </strong>
        ///         methods.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml'
        ///     path="/comments/comment[@id='ID2D1RenderTarget::PopAxisAlignedClip']/*" />
        /// <msdn-id>dd316850</msdn-id>
        /// <unmanaged>void ID2D1RenderTarget::PopAxisAlignedClip()</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::PopAxisAlignedClip</unmanaged-short>
        void PopAxisAlignedClip();

        /// <summary>
        ///     <p>Clears the drawing area to the specified color. </p>
        /// </summary>
        /// <param name="clearColor">
        ///     <dd>
        ///         <p>
        ///             The color to which the drawing area is cleared, or
        ///             <strong>
        ///                 <c>null</c>
        ///             </strong>
        ///             for transparent black.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <remarks>
        ///     <p>
        ///         Direct2D interprets the <em>clearColor</em> as straight alpha (not premultiplied).  If the render target's
        ///         alpha mode is
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.AlphaMode.Ignore" />
        ///         </strong>
        ///         , the alpha channel of <em>clearColor</em> is ignored and replaced with 1.0f (fully opaque).
        ///     </p>
        ///     <p>
        ///         If the render target has an active clip (specified by <strong>PushAxisAlignedClip</strong>), the clear command
        ///         is applied only to the area within the clip region.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::Clear']/*" />
        /// <msdn-id>dd371769</msdn-id>
        /// <unmanaged>void ID2D1RenderTarget::Clear([In, Optional] const D2D_COLOR_F* clearColor)</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::Clear</unmanaged-short>
        void Clear(Color4? clearColor);

        /// <summary>
        ///     <p>Initiates drawing on this render target. </p>
        /// </summary>
        /// <remarks>
        ///     <p>Drawing operations can only be issued between a <strong>BeginDraw</strong> and <strong>EndDraw</strong> call.</p>
        ///     <p>
        ///         BeginDraw and EndDraw are used to indicate that a render target is in use by the Direct2D system. Different
        ///         implementations of
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget" />
        ///         </strong>
        ///         might behave differently when <strong>BeginDraw</strong> is called. An
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.BitmapRenderTarget" />
        ///         </strong>
        ///         may be locked between <strong>BeginDraw</strong>/<strong>EndDraw</strong> calls, a DXGI surface render target
        ///         might be acquired on <strong>BeginDraw</strong> and released on <strong>EndDraw</strong>, while an
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.WindowRenderTarget" />
        ///         </strong>
        ///         may begin batching at <strong>BeginDraw</strong> and may present on <strong>EndDraw</strong>, for example.
        ///     </p>
        ///     <p>
        ///         The BeginDraw method must be called before rendering operations can be called, though state-setting and
        ///         state-retrieval operations can be performed even outside of <strong>BeginDraw</strong>/<strong>EndDraw</strong>
        ///         .
        ///     </p>
        ///     <p>
        ///         After <strong>BeginDraw</strong> is called, a render target will normally build up a batch of rendering
        ///         commands, but defer processing of these commands until either an internal buffer is full, the
        ///         <strong>Flush</strong> method is called, or until <strong>EndDraw</strong> is called. The
        ///         <strong>EndDraw</strong> method causes any batched drawing operations to complete, and then returns an
        ///         <see cref="SharpDX.Result" /> indicating the success of the operations and, optionally, the tag state of the
        ///         render target at the time the error occurred. The <strong>EndDraw</strong> method always succeeds: it should
        ///         not be called twice even if a previous <strong>EndDraw</strong> resulted in a failing
        ///         <see cref="SharpDX.Result" />.
        ///     </p>
        ///     <p>
        ///         If <strong>EndDraw</strong> is called without a matched call to <strong>BeginDraw</strong>, it returns an error
        ///         indicating that <strong>BeginDraw</strong> must be called before <strong>EndDraw</strong>. Calling
        ///         <strong>BeginDraw</strong> twice on a render target puts the target into an error state where nothing further
        ///         is drawn, and returns an appropriate <see cref="SharpDX.Result" /> and error information when
        ///         <strong>EndDraw</strong> is called.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::BeginDraw']/*" />
        /// <msdn-id>dd371768</msdn-id>
        /// <unmanaged>void ID2D1RenderTarget::BeginDraw()</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::BeginDraw</unmanaged-short>
        void BeginDraw();

        /// <summary>
        ///     <p>Ends drawing operations  on the render target and indicates the current error state and associated tags. </p>
        /// </summary>
        /// <param name="tag1">
        ///     <dd>
        ///         <p>
        ///             When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no
        ///             errors. This parameter is passed uninitialized.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <param name="tag2">
        ///     <dd>
        ///         <p>
        ///             When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no
        ///             errors. This parameter is passed uninitialized.
        ///         </p>
        ///     </dd>
        /// </param>
        /// <returns>
        ///     <p>
        ///         If the method succeeds, it returns
        ///         <strong>
        ///             <see cref="SharpDX.Result.Ok" />
        ///         </strong>
        ///         . Otherwise, it returns an
        ///         <strong>
        ///             <see cref="SharpDX.Result" />
        ///         </strong>
        ///         error code and sets <em>tag1</em> and <em>tag2</em> to the tags that were active when the error occurred.
        ///     </p>
        /// </returns>
        /// <remarks>
        ///     <p>Drawing operations can only be issued between a <strong>BeginDraw</strong> and <strong>EndDraw</strong> call.</p>
        ///     <p>
        ///         <strong>BeginDraw</strong> and <strong>EndDraw</strong> are use to indicate that a render target is in use by
        ///         the Direct2D system. Different implementations of
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.RenderTarget" />
        ///         </strong>
        ///         might behave differently when <strong>BeginDraw</strong> is called. An
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.BitmapRenderTarget" />
        ///         </strong>
        ///         may be locked between <strong>BeginDraw</strong>/<strong>EndDraw</strong> calls, a DXGI surface render target
        ///         might be acquired on <strong>BeginDraw</strong> and released on <strong>EndDraw</strong>, while an
        ///         <strong>
        ///             <see cref="SharpDX.Direct2D1.WindowRenderTarget" />
        ///         </strong>
        ///         may begin batching at <strong>BeginDraw</strong> and may present on <strong>EndDraw</strong>, for example.
        ///     </p>
        ///     <p>
        ///         The <strong>BeginDraw</strong> method must be called before rendering operations can be called, though
        ///         state-setting and state-retrieval operations can be performed even outside of <strong>BeginDraw</strong>/
        ///         <strong>EndDraw</strong>.
        ///     </p>
        ///     <p>
        ///         After <strong>BeginDraw</strong> is called, a render target will normally build up a batch of rendering
        ///         commands, but defer processing of these commands until either an internal buffer is full, the
        ///         <strong>Flush</strong> method is called, or until <strong>EndDraw</strong> is called. The
        ///         <strong>EndDraw</strong> method causes any batched drawing operations to complete, and then returns an
        ///         <strong>
        ///             <see cref="SharpDX.Result" />
        ///         </strong>
        ///         indicating the success of the operations and, optionally, the tag state of the render target at the time the
        ///         error occurred. The <strong>EndDraw</strong> method always succeeds: it should not be called twice even if a
        ///         previous <strong>EndDraw</strong> resulted in a failing
        ///         <strong>
        ///             <see cref="SharpDX.Result" />
        ///         </strong>
        ///         .
        ///     </p>
        ///     <p>
        ///         If <strong>EndDraw</strong> is called without a matched call to <strong>BeginDraw</strong>, it returns an error
        ///         indicating that <strong>BeginDraw</strong> must be called before <strong>EndDraw</strong>. Calling
        ///         <strong>BeginDraw</strong> twice on a render target puts the target into an error state where nothing further
        ///         is drawn, and returns an appropriate
        ///         <strong>
        ///             <see cref="SharpDX.Result" />
        ///         </strong>
        ///         and error information when <strong>EndDraw</strong> is called.
        ///     </p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::EndDraw']/*" />
        /// <msdn-id>dd371924</msdn-id>
        /// <unmanaged>
        ///     HRESULT ID2D1RenderTarget::EndDraw([Out, Optional] unsigned longlong* tag1,[Out, Optional] unsigned
        ///     longlong* tag2)
        /// </unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::EndDraw</unmanaged-short>
        void EndDraw(out long tag1, out long tag2);

        /// <summary>
        ///     <p>Indicates whether the render target supports the specified properties.</p>
        /// </summary>
        /// <param name="renderTargetProperties">
        ///     <dd>
        ///         <p>The render target properties to test.</p>
        ///     </dd>
        /// </param>
        /// <returns>
        ///     <p>
        ///         <strong>TRUE</strong> if the specified render target properties are supported by this render target; otherwise,
        ///         <strong>
        ///             <see cref="SharpDX.Result.False" />
        ///         </strong>
        ///         .
        ///     </p>
        /// </returns>
        /// <remarks>
        ///     <p>This method does not evaluate the DPI settings specified by the <em>renderTargetProperties</em> parameter.</p>
        /// </remarks>
        /// <include file='.\..\Documentation\CodeComments.xml' path="/comments/comment[@id='ID2D1RenderTarget::IsSupported']/*" />
        /// <msdn-id>dd742854</msdn-id>
        /// <unmanaged>BOOL ID2D1RenderTarget::IsSupported([In] const D2D1_RENDER_TARGET_PROPERTIES* renderTargetProperties)</unmanaged>
        /// <unmanaged-short>ID2D1RenderTarget::IsSupported</unmanaged-short>
        Bool IsSupported(ref RenderTargetProperties renderTargetProperties);

        /// <summary>
        ///     Draws the specified bitmap after scaling it to the size of the specified rectangle.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///     {{DrawBitmap}}) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="bitmap">The bitmap to render. </param>
        /// <param name="opacity">
        ///     A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap;
        ///     this value is multiplied against the alpha values of the bitmap's contents.  The default value is 1.0f.
        /// </param>
        /// <param name="interpolationMode">
        ///     The interpolation mode to use if the bitmap is scaled or rotated by the drawing
        ///     operation. The default value is <see cref="F:SharpDX.Direct2D1.BitmapInterpolationMode.Linear" />.
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawBitmap([In] ID2D1Bitmap* bitmap,[In, Optional] const D2D1_RECT_F*
        ///     destinationRectangle,[None] float opacity,[None] D2D1_BITMAP_INTERPOLATION_MODE interpolationMode,[In, Optional]
        ///     const D2D1_RECT_F* sourceRectangle)
        /// </unmanaged>
        void DrawBitmap(Bitmap bitmap, float opacity, BitmapInterpolationMode interpolationMode);

        /// <summary>
        ///     Draws the specified bitmap after scaling it to the size of the specified rectangle.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///     {{DrawBitmap}}) failed, check the result returned by the <see cref="RenderTarget.EndDraw()" /> or
        ///     <see cref="RenderTarget.Flush()" /> methods.
        /// </remarks>
        /// <param name="bitmap">The bitmap to render. </param>
        /// <param name="destinationRectangle">
        ///     The size and position, in device-independent pixels in the render target's
        ///     coordinate space, of the area to which the bitmap is drawn; NULL to draw the selected portion of the bitmap at the
        ///     origin of the render target.  If the rectangle is specified but not well-ordered, nothing is drawn, but the render
        ///     target does not enter an error state.
        /// </param>
        /// <param name="opacity">
        ///     A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap;
        ///     this value is multiplied against the alpha values of the bitmap's contents.  The default value is 1.0f.
        /// </param>
        /// <param name="interpolationMode">
        ///     The interpolation mode to use if the bitmap is scaled or rotated by the drawing
        ///     operation. The default value is <see cref="SharpDX.Direct2D1.BitmapInterpolationMode.Linear" />.
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawBitmap([In] ID2D1Bitmap* bitmap,[In, Optional] const D2D1_RECT_F*
        ///     destinationRectangle,[None] float opacity,[None] D2D1_BITMAP_INTERPOLATION_MODE interpolationMode,[In, Optional]
        ///     const D2D1_RECT_F* sourceRectangle)
        /// </unmanaged>
        void DrawBitmap(Bitmap bitmap, RectangleF destinationRectangle, float opacity,
            BitmapInterpolationMode interpolationMode);

        /// <summary>
        ///     Draws the specified bitmap after scaling it to the size of the specified rectangle.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///     {{DrawBitmap}}) failed, check the result returned by the <see cref="RenderTarget.EndDraw()" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="bitmap">The bitmap to render. </param>
        /// <param name="opacity">
        ///     A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap;
        ///     this value is multiplied against the alpha values of the bitmap's contents.  The default value is 1.0f.
        /// </param>
        /// <param name="interpolationMode">
        ///     The interpolation mode to use if the bitmap is scaled or rotated by the drawing
        ///     operation. The default value is <see cref="F:SharpDX.Direct2D1.BitmapInterpolationMode.Linear" />.
        /// </param>
        /// <param name="sourceRectangle">
        ///     The size and position, in device-independent pixels in the bitmap's coordinate space, of
        ///     the area within the bitmap to be drawn; NULL to draw the entire bitmap.
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawBitmap([In] ID2D1Bitmap* bitmap,[In, Optional] const D2D1_RECT_F*
        ///     destinationRectangle,[None] float opacity,[None] D2D1_BITMAP_INTERPOLATION_MODE interpolationMode,[In, Optional]
        ///     const D2D1_RECT_F* sourceRectangle)
        /// </unmanaged>
        void DrawBitmap(Bitmap bitmap, float opacity, BitmapInterpolationMode interpolationMode,
            RectangleF sourceRectangle);

        /// <summary>
        ///     Draws the outline of the specified ellipse using the specified stroke style.
        /// </summary>
        /// <remarks>
        ///     The {{DrawEllipse}} method doesn't return an error code if it fails. To determine whether a drawing operation (such
        ///     as DrawEllipse) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="ellipse">The position and radius of the ellipse to draw, in device-independent pixels. </param>
        /// <param name="brush">The brush used to paint the ellipse's outline. </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawEllipse([In] const D2D1_ELLIPSE* ellipse,[In] ID2D1Brush* brush,[None] float
        ///     strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawEllipse(Ellipse ellipse, Brush brush);

        /// <summary>
        ///     Draws the outline of the specified ellipse using the specified stroke style.
        /// </summary>
        /// <remarks>
        ///     The {{DrawEllipse}} method doesn't return an error code if it fails. To determine whether a drawing operation (such
        ///     as DrawEllipse) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="ellipse">The position and radius of the ellipse to draw, in device-independent pixels. </param>
        /// <param name="brush">The brush used to paint the ellipse's outline. </param>
        /// <param name="strokeWidth">The thickness of the ellipse's stroke. The stroke is centered on the ellipse's outline. </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawEllipse([In] const D2D1_ELLIPSE* ellipse,[In] ID2D1Brush* brush,[None] float
        ///     strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawEllipse(Ellipse ellipse, Brush brush, float strokeWidth);

        /// <summary>
        ///     Draws the outline of the specified geometry.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///     DrawGeometry) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="geometry">The geometry to draw. </param>
        /// <param name="brush">The brush used to paint the geometry's stroke. </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawGeometry([In] ID2D1Geometry* geometry,[In] ID2D1Brush* brush,[None] float
        ///     strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawGeometry(Geometry geometry, Brush brush);

        /// <summary>
        ///     Draws the outline of the specified geometry.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///     DrawGeometry) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="geometry">The geometry to draw. </param>
        /// <param name="brush">The brush used to paint the geometry's stroke. </param>
        /// <param name="strokeWidth">The thickness of the geometry's stroke. The stroke is centered on the geometry's outline. </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawGeometry([In] ID2D1Geometry* geometry,[In] ID2D1Brush* brush,[None] float
        ///     strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawGeometry(Geometry geometry, Brush brush, float strokeWidth);

        /// <summary>
        ///     Draws a line between the specified points.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawLine)
        ///     failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="point0">The start point of the line, in device-independent pixels. </param>
        /// <param name="point1">The end point of the line, in device-independent pixels. </param>
        /// <param name="brush">The brush used to paint the line's stroke. </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawLine([None] D2D1_POINT_2F point0,[None] D2D1_POINT_2F point1,[In] ID2D1Brush*
        ///     brush,[None] float strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawLine(Vector2 point0, Vector2 point1, Brush brush);

        /// <summary>
        ///     Draws a line between the specified points.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawLine)
        ///     failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="point0">The start point of the line, in device-independent pixels. </param>
        /// <param name="point1">The end point of the line, in device-independent pixels. </param>
        /// <param name="brush">The brush used to paint the line's stroke. </param>
        /// <param name="strokeWidth">
        ///     A value greater than or equal to 0.0f that specifies the width of the stroke. If this
        ///     parameter isn't specified, it defaults to 1.0f.  The stroke is centered on the line.
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawLine([None] D2D1_POINT_2F point0,[None] D2D1_POINT_2F point1,[In] ID2D1Brush*
        ///     brush,[None] float strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawLine(Vector2 point0, Vector2 point1, Brush brush, float strokeWidth);

        /// <summary>
        ///     Draws the outline of a rectangle that has the specified dimensions.
        /// </summary>
        /// <remarks>
        ///     When this method fails, it does not return an error code. To determine whether a drawing method (such as
        ///     {{DrawRectangle}}) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> method.
        /// </remarks>
        /// <param name="rect">The dimensions of the rectangle to draw, in device-independent pixels. </param>
        /// <param name="brush">The brush used to paint the rectangle's stroke. </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawRectangle([In] const D2D1_RECT_F* rect,[In] ID2D1Brush* brush,[None] float
        ///     strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawRectangle(RectangleF rect, Brush brush);

        /// <summary>
        ///     Draws the outline of a rectangle that has the specified dimensions and stroke style.
        /// </summary>
        /// <remarks>
        ///     When this method fails, it does not return an error code. To determine whether a drawing method (such as
        ///     {{DrawRectangle}}) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> method.
        /// </remarks>
        /// <param name="rect">The dimensions of the rectangle to draw, in device-independent pixels. </param>
        /// <param name="brush">The brush used to paint the rectangle's stroke. </param>
        /// <param name="strokeWidth">
        ///     A value greater than or equal to 0.0f that specifies the width of the rectangle's stroke. The
        ///     stroke is centered on the rectangle's outline.
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawRectangle([In] const D2D1_RECT_F* rect,[In] ID2D1Brush* brush,[None] float
        ///     strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawRectangle(RectangleF rect, Brush brush, float strokeWidth);

        /// <summary>
        ///     Draws the outline of the specified rounded rectangle.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///     {{DrawRoundedRectangle}}) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels. </param>
        /// <param name="brush">The brush used to paint the rounded rectangle's outline.  </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawRoundedRectangle([In] const D2D1_ROUNDED_RECT* roundedRect,[In] ID2D1Brush*
        ///     brush,[None] float strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawRoundedRectangle(RoundedRectangle roundedRect, Brush brush);

        /// <summary>
        ///     Draws the outline of the specified rounded rectangle.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///     {{DrawRoundedRectangle}}) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels. </param>
        /// <param name="brush">The brush used to paint the rounded rectangle's outline.  </param>
        /// <param name="strokeWidth">
        ///     The width of the rounded rectangle's stroke. The stroke is centered on the rounded
        ///     rectangle's outline. The default value is 1.0f.
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawRoundedRectangle([In] const D2D1_ROUNDED_RECT* roundedRect,[In] ID2D1Brush*
        ///     brush,[None] float strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawRoundedRectangle(RoundedRectangle roundedRect, Brush brush, float strokeWidth);

        /// <summary>
        ///     Draws the outline of the specified rounded rectangle using the specified stroke style.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///     {{DrawRoundedRectangle}}) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels. </param>
        /// <param name="brush">The brush used to paint the rounded rectangle's outline.  </param>
        /// <param name="strokeWidth">
        ///     The width of the rounded rectangle's stroke. The stroke is centered on the rounded
        ///     rectangle's outline. The default value is 1.0f.
        /// </param>
        /// <param name="strokeStyle">
        ///     The style of the rounded rectangle's stroke, or NULL to paint a solid stroke. The default
        ///     value is NULL.
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawRoundedRectangle([In] const D2D1_ROUNDED_RECT* roundedRect,[In] ID2D1Brush*
        ///     brush,[None] float strokeWidth,[In, Optional] ID2D1StrokeStyle* strokeStyle)
        /// </unmanaged>
        void DrawRoundedRectangle(RoundedRectangle roundedRect, Brush brush, float strokeWidth, StrokeStyle strokeStyle);

        /// <summary>
        ///     Draws the specified text using the format information provided by an
        ///     <see cref="T:SharpDX.DirectWrite.TextFormat" /> object.
        /// </summary>
        /// <remarks>
        ///     To create an <see cref="T:SharpDX.DirectWrite.TextFormat" /> object, create an
        ///     <see cref="T:SharpDX.DirectWrite.Factory" /> and call its {{CreateTextFormat}} method. This method doesn't return
        ///     an error code if it fails. To determine whether a drawing operation (such as {{DrawText}}) failed, check the result
        ///     returned by the <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="text">A reference to an array of Unicode characters to draw.  </param>
        /// <param name="textFormat">
        ///     An object that describes formatting details of the text to draw, such as the font, the font
        ///     size, and flow direction.
        /// </param>
        /// <param name="layoutRect">The size and position of the area in which the text is drawn.  </param>
        /// <param name="defaultForegroundBrush">The brush used to paint the text. </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawTextA([In, Buffer] const wchar_t* string,[None] int stringLength,[In]
        ///     IDWriteTextFormat* textFormat,[In] const D2D1_RECT_F* layoutRect,[In] ID2D1Brush* defaultForegroundBrush,[None]
        ///     D2D1_DRAW_TEXT_OPTIONS options,[None] DWRITE_MEASURING_MODE measuringMode)
        /// </unmanaged>
        void DrawText(string text, TextFormat textFormat, RectangleF layoutRect, Brush defaultForegroundBrush);

        /// <summary>
        ///     Draws the specified text using the format information provided by an
        ///     <see cref="T:SharpDX.DirectWrite.TextFormat" /> object.
        /// </summary>
        /// <remarks>
        ///     To create an <see cref="T:SharpDX.DirectWrite.TextFormat" /> object, create an
        ///     <see cref="T:SharpDX.DirectWrite.Factory" /> and call its {{CreateTextFormat}} method. This method doesn't return
        ///     an error code if it fails. To determine whether a drawing operation (such as {{DrawText}}) failed, check the result
        ///     returned by the <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="text">A reference to an array of Unicode characters to draw.  </param>
        /// <param name="textFormat">
        ///     An object that describes formatting details of the text to draw, such as the font, the font
        ///     size, and flow direction.
        /// </param>
        /// <param name="layoutRect">The size and position of the area in which the text is drawn.  </param>
        /// <param name="defaultForegroundBrush">The brush used to paint the text. </param>
        /// <param name="options">
        ///     A value that indicates whether the text should be snapped to pixel boundaries and whether the
        ///     text should be clipped to the layout rectangle. The default value is
        ///     <see cref="F:SharpDX.Direct2D1.DrawTextOptions.None" />, which indicates that text should be snapped to pixel
        ///     boundaries and it should not be clipped to the layout rectangle.
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawTextA([In, Buffer] const wchar_t* string,[None] int stringLength,[In]
        ///     IDWriteTextFormat* textFormat,[In] const D2D1_RECT_F* layoutRect,[In] ID2D1Brush* defaultForegroundBrush,[None]
        ///     D2D1_DRAW_TEXT_OPTIONS options,[None] DWRITE_MEASURING_MODE measuringMode)
        /// </unmanaged>
        void DrawText(string text, TextFormat textFormat, RectangleF layoutRect, Brush defaultForegroundBrush,
            DrawTextOptions options);

        /// <summary>
        ///     Draws the specified text using the format information provided by an
        ///     <see cref="T:SharpDX.DirectWrite.TextFormat" /> object.
        /// </summary>
        /// <remarks>
        ///     To create an <see cref="T:SharpDX.DirectWrite.TextFormat" /> object, create an
        ///     <see cref="T:SharpDX.DirectWrite.Factory" /> and call its {{CreateTextFormat}} method. This method doesn't return
        ///     an error code if it fails. To determine whether a drawing operation (such as {{DrawText}}) failed, check the result
        ///     returned by the <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="text">A reference to an array of Unicode characters to draw.  </param>
        /// <param name="textFormat">
        ///     An object that describes formatting details of the text to draw, such as the font, the font
        ///     size, and flow direction.
        /// </param>
        /// <param name="layoutRect">The size and position of the area in which the text is drawn.  </param>
        /// <param name="defaultForegroundBrush">The brush used to paint the text. </param>
        /// <param name="options">
        ///     A value that indicates whether the text should be snapped to pixel boundaries and whether the
        ///     text should be clipped to the layout rectangle. The default value is
        ///     <see cref="F:SharpDX.Direct2D1.DrawTextOptions.None" />, which indicates that text should be snapped to pixel
        ///     boundaries and it should not be clipped to the layout rectangle.
        /// </param>
        /// <param name="measuringMode">
        ///     A value that indicates how glyph metrics are used to measure text when it is formatted.
        ///     The default value is DWRITE_MEASURING_MODE_NATURAL.
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawTextA([In, Buffer] const wchar_t* string,[None] int stringLength,[In]
        ///     IDWriteTextFormat* textFormat,[In] const D2D1_RECT_F* layoutRect,[In] ID2D1Brush* defaultForegroundBrush,[None]
        ///     D2D1_DRAW_TEXT_OPTIONS options,[None] DWRITE_MEASURING_MODE measuringMode)
        /// </unmanaged>
        void DrawText(string text, TextFormat textFormat, RectangleF layoutRect, Brush defaultForegroundBrush,
            DrawTextOptions options, MeasuringMode measuringMode);

        /// <summary>
        ///     Draws the formatted text described by the specified <see cref="T:SharpDX.DirectWrite.TextLayout" /> object.
        /// </summary>
        /// <remarks>
        ///     When drawing the same text repeatedly, using the DrawTextLayout method is more efficient than using the
        ///     {{DrawText}} method because the text doesn't need to be formatted and the layout processed with each call. This
        ///     method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawTextLayout)
        ///     failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="origin">
        ///     The point, described in device-independent pixels, at which the upper-left corner of the text
        ///     described by textLayout is drawn.
        /// </param>
        /// <param name="textLayout">
        ///     The formatted text to draw. Any drawing effects that do not inherit from
        ///     <see cref="T:SharpDX.Direct2D1.Resource" /> are ignored. If there are drawing effects that inherit from
        ///     ID2D1Resource that are not brushes, this method fails and the render target is put in an error state.
        /// </param>
        /// <param name="defaultForegroundBrush">
        ///     The brush used to paint any text in textLayout that does not already have a brush
        ///     associated with it as a drawing effect (specified by the
        ///     <see cref="M:SharpDX.DirectWrite.TextLayout.SetDrawingEffect(SharpDX.ComObject,SharpDX.DirectWrite.TextRange)" />
        ///     method).
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::DrawTextLayout([None] D2D1_POINT_2F origin,[In] IDWriteTextLayout* textLayout,[In]
        ///     ID2D1Brush* defaultForegroundBrush,[None] D2D1_DRAW_TEXT_OPTIONS options)
        /// </unmanaged>
        void DrawTextLayout(Vector2 origin, TextLayout textLayout, Brush defaultForegroundBrush);

        /// <summary>
        ///     Ends drawing operations  on the render target and indicates the current error state and associated tags.
        /// </summary>
        /// <remarks>
        ///     Drawing operations can only be issued between a {{BeginDraw}} and EndDraw call.BeginDraw and EndDraw are use to
        ///     indicate that a render target is in use by the Direct2D system. Different implementations of
        ///     <see cref="SharpDX.Direct2D1.RenderTarget" /> might behave differently when {{BeginDraw}} is called. An
        ///     <see cref="SharpDX.Direct2D1.BitmapRenderTarget" /> may be locked between BeginDraw/EndDraw calls, a DXGI surface
        ///     render target might be acquired on BeginDraw and released on EndDraw, while an <see cref="WindowRenderTarget" />
        ///     may begin batching at BeginDraw and may present on EndDraw, for example. The BeginDraw method must be called before
        ///     rendering operations can be called, though state-setting and state-retrieval operations can be performed even
        ///     outside of {{BeginDraw}}/EndDraw. After {{BeginDraw}} is called, a render target will normally build up a batch of
        ///     rendering commands, but defer processing of these commands until either an internal buffer is full, the {{Flush}}
        ///     method is called, or until EndDraw is called. The EndDraw method causes any batched drawing operations to complete,
        ///     and then returns an HRESULT indicating the success of the operations and, optionally, the tag state of the render
        ///     target at the time the error occurred. The EndDraw method always succeeds: it should not be called twice even if a
        ///     previous EndDraw resulted in a failing HRESULT. If EndDraw is called without a matched call to {{BeginDraw}}, it
        ///     returns an error indicating that BeginDraw must be called before EndDraw. Calling BeginDraw twice on a render
        ///     target puts the target into an error state where nothing further is drawn, and returns an appropriate HRESULT and
        ///     error information when EndDraw is called.
        /// </remarks>
        /// <returns>
        ///     If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code and sets tag1 and tag2 to
        ///     the tags that were active when the error occurred.
        /// </returns>
        void EndDraw();

        /// <summary>
        ///     Paints the interior of the specified geometry.
        /// </summary>
        /// <remarks>
        ///     If the opacityBrush parameter is not NULL, the alpha value of each pixel of the mapped opacityBrush is used to
        ///     determine the resulting opacity of each corresponding pixel of the geometry. Only the alpha value of each color in
        ///     the brush is used for this processing; all other color information is ignored.  The alpha value specified by the
        ///     brush is multiplied by the alpha value of the geometry after the geometry has been painted by brush.
        ///     When this method fails, it does not return an error code. To determine whether a drawing operation (such as
        ///     FillGeometry) failed, check the result returned by the <see cref="RenderTarget.EndDraw()" /> or
        ///     <see cref="RenderTarget.Flush()" /> method.
        /// </remarks>
        /// <param name="geometry">The geometry to paint.</param>
        /// <param name="brush">The brush used to paint the geometry's interior.</param>
        /// <unmanaged>
        ///     void FillGeometry([In] ID2D1Geometry* geometry,[In] ID2D1Brush* brush,[In, Optional] ID2D1Brush*
        ///     opacityBrush)
        /// </unmanaged>
        void FillGeometry(Geometry geometry, Brush brush);

        /// <summary>
        ///     Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the
        ///     render target.
        /// </summary>
        /// <remarks>
        ///     For this method to work properly, the render target must be using the
        ///     <see cref="F:SharpDX.Direct2D1.AntialiasMode.Aliased" /> antialiasing mode. You can set the antialiasing mode by
        ///     calling the <see cref="M:SharpDX.Direct2D1.RenderTarget.SetAntialiasMode(SharpDX.Direct2D1.AntialiasMode)" />
        ///     method. This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///     {{FillOpacityMask}}) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="opacityMask">
        ///     The opacity mask to apply to the brush. The alpha value of each pixel in the  region
        ///     specified by sourceRectangle is multiplied with the alpha value of the brush after the brush has been mapped to the
        ///     area defined by destinationRectangle.
        /// </param>
        /// <param name="brush">The brush used to paint the region of the render target specified by destinationRectangle. </param>
        /// <param name="content">
        ///     The type of content the opacity mask contains. The value is used to determine the color space in
        ///     which the opacity mask is blended.
        /// </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::FillOpacityMask([In] ID2D1Bitmap* opacityMask,[In] ID2D1Brush* brush,[None]
        ///     D2D1_OPACITY_MASK_CONTENT content,[In, Optional] const D2D1_RECT_F* destinationRectangle,[In, Optional] const
        ///     D2D1_RECT_F* sourceRectangle)
        /// </unmanaged>
        void FillOpacityMask(Bitmap opacityMask, Brush brush, OpacityMaskContent content);

        /// <summary>
        ///     Paints the interior of the specified rounded rectangle.
        /// </summary>
        /// <remarks>
        ///     This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
        ///     {{FillRoundedRectangle}}) failed, check the result returned by the
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.EndDraw(System.Int64@,System.Int64@)" /> or
        ///     <see cref="M:SharpDX.Direct2D1.RenderTarget.Flush(System.Int64@,System.Int64@)" /> methods.
        /// </remarks>
        /// <param name="roundedRect">The dimensions of the rounded rectangle to paint, in device-independent pixels. </param>
        /// <param name="brush">The brush used to paint the interior of the rounded rectangle. </param>
        /// <unmanaged>
        ///     void ID2D1RenderTarget::FillRoundedRectangle([In] const D2D1_ROUNDED_RECT* roundedRect,[In] ID2D1Brush*
        ///     brush)
        /// </unmanaged>
        void FillRoundedRectangle(RoundedRectangle roundedRect, Brush brush);

        /// <summary>
        ///     Executes all pending drawing commands.
        /// </summary>
        /// <remarks>
        ///     This command does not flush the device that is associated with the render target.   Calling this method resets the
        ///     error state of the render target.
        /// </remarks>
        /// <returns>
        ///     If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code and sets tag1 and tag2 to
        ///     the tags that were active when the error occurred. If no error occurred, this method sets the error tag state to be
        ///     (0,0).
        /// </returns>
        /// <unmanaged>HRESULT ID2D1RenderTarget::Flush([Out, Optional] D2D1_TAG* tag1,[Out, Optional] D2D1_TAG* tag2)</unmanaged>
        void Flush();

        /// <summary>
        ///     Query this instance for a particular COM GUID/interface support.
        /// </summary>
        /// <param name="guid">GUID query interface</param>
        /// <param name="outPtr">output object associated with this GUID, IntPtr.Zero in interface is not supported</param>
        /// <exception cref="SharpDXException">If this object doesn't support the interface</exception>
        /// <msdn-id>ms682521</msdn-id>
        /// <unmanaged>IUnknown::QueryInterface</unmanaged>
        /// <unmanaged-short>IUnknown::QueryInterface</unmanaged-short>
        void QueryInterface(Guid guid, out IntPtr outPtr);

        /// <summary>
        ///     Query instance for a particular COM GUID/interface support.
        /// </summary>
        /// <param name="guid">GUID query interface</param>
        /// <exception cref="SharpDXException">If this object doesn't support the interface</exception>
        /// <msdn-id>ms682521</msdn-id>
        /// <unmanaged>IUnknown::QueryInterface</unmanaged>
        /// <unmanaged-short>IUnknown::QueryInterface</unmanaged-short>
        IntPtr QueryInterfaceOrNull(Guid guid);

        /// <summary>
        ///     Query this instance for a particular COM interface support.
        /// </summary>
        /// <typeparam name="T">The type of the COM interface to query</typeparam>
        /// <returns>An instance of the queried interface</returns>
        /// <exception cref="SharpDXException">If this object doesn't support the interface</exception>
        /// <msdn-id>ms682521</msdn-id>
        /// <unmanaged>IUnknown::QueryInterface</unmanaged>
        /// <unmanaged-short>IUnknown::QueryInterface</unmanaged-short>
        T QueryInterface<T>() where T : ComObject;

        /// <summary>
        ///     Query Interface for a particular interface support.
        /// </summary>
        /// <returns>An instance of the queried interface or null if it is not supported</returns>
        /// <returns></returns>
        /// <msdn-id>ms682521</msdn-id>
        /// <unmanaged>IUnknown::QueryInterface</unmanaged>
        /// <unmanaged-short>IUnknown::QueryInterface</unmanaged-short>
        T QueryInterfaceOrNull<T>() where T : ComObject;

        /// <summary>
        ///     Occurs when this instance is starting to be disposed.
        /// </summary>
        event EventHandler<EventArgs> Disposing;

        /// <summary>
        ///     Occurs when this instance is fully disposed.
        /// </summary>
        event EventHandler<EventArgs> Disposed;

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void Dispose();
    }
}