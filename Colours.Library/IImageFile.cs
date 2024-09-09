using Colours.Extensions;
using Colours.Library.PixelTypes;

// third party:
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SkiaSharp;

namespace Colours.Library
{
    public interface IImageFile
    {
        public int Height { get; }
        public int Width { get; }
        public void Deconstruct(out int height, out int width);
        public ref Rgba GetPixel(int x, int y);
    }
}