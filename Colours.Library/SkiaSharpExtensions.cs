// extension methods for SkiaSharp
using SkiaSharp;
using Colours.Library;
using Colours.Library.PixelTypes;

namespace Colours.Extensions
{
    // type aliases
    public static class SkiaSharpExtensions
    {

        public static System.UInt32 ToUint32(this SkiaSharp.SKColor skcolor)
        {
            byte red = skcolor.Red;
            byte green = skcolor.Green;
            byte blue = skcolor.Blue;
            byte alpha = skcolor.Alpha;
            return Utilities.CreateIntegerFromComponent(red, green, blue, alpha);
        }

        public static Colours.Library.PixelTypes.Rgba ToColoursRgba(this SkiaSharp.SKColor skcolor)
        {
            byte red = skcolor.Red;
            byte green = skcolor.Green;
            byte blue = skcolor.Blue;
            byte alpha = skcolor.Alpha;
            return new(red, green, blue, alpha);
        }
    }
}