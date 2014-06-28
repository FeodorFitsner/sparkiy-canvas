namespace SharpDX.Toolkit.Direct2D.Test.Extras {
    public static class ColorExtensions
    {
        public static Color ChangeAlpha(this Color color, float alpha)
        {
            return new Color(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, 1.0f / 255.0f * alpha);
        }
    }
}