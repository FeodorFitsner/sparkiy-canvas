SharpDX.Toolkit.Game.Direct2D
=============================

Provides Direct2D and DirectWrite to Toolkit's Game class


This is an (unofficial) preliminary implementation that might eventually get integrated in the next iteration of the Toolkit.

**Note**

This project is a temporary repository used as a test for the time being, it will get renamed and become stand-alone in the future. A Nuget package will certainly be available as well as other platforms (TBD) because right now it only targets WinRT.

**Issues**

~~The ```Direct2DService``` class still has some problems when window gets resized, the origin of the problem is explained here: https://github.com/aybe/SharpDX.Toolkit.Game.Direct2D/blob/master/SharpDX.Toolkit.Game.Ex.WinRT/Direct2DService.cs#L133~~ : **fixed by xoofx** (https://github.com/xoofx)

**Future**

Bitmap caching feature for Direct2D and probably DirectWrite as well since calling these APIs in the long run can have a significant impact on frame rate.
