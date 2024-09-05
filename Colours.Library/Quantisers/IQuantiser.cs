// Interface for Quantising Methods

using System.Collections.Generic;

// third party
using SixLabors.ImageSharp.PixelFormats;

namespace Colours.Library.Quantisers
{
    using ColourType = System.UInt32;

    interface IQuantiser
    {
        // The quantisation method is provided for a variety of image file providers
        public void Quantise(SixLabors.ImageSharp.Image<Rgba32> image);
        public void Quantise(SkiaSharp.SKBitmap image);
        public HashSet<ColourType> GetColours();
        public List<ColourType> GetTopColours(int top);
    }
}