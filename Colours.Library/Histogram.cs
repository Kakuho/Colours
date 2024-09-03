// A class to represent the histogram method for colour quantisation

using System.Collections.Generic;
using System.Drawing;
using Colours.Extensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SkiaSharp;

namespace Colours.Library
{

    // sane type aliases
    using ColourType = System.UInt32;
    using CountType = System.UInt128;

    public class Histogram: IQuantiser
    {
        private Dictionary<ColourType, CountType> _lut;

        public Histogram()
        {
            _lut = new();
        }

        public void Quantise(Image<Rgba32> image)
        {
            Console.WriteLine("quantising the Imagesharp image");
            image.ProcessPixelRows(accessor =>
            {
                for (int y = 0; y < accessor.Height; y++)
                {
                    Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                    for (int x = 0; x < pixelRow.Length; x++)
                    {
                        // Get a reference to the pixel at position x
                        ref Rgba32 pixel = ref pixelRow[x];
                        //Console.WriteLine($"{pixel.ToHex():8}");
                        ColourType colour = Convert.ToUInt32(pixel.ToHex(), 16);
                        if (!_lut.ContainsKey(colour))
                        {
                            _lut[colour] = 0; ;
                        }
                        else
                        {
                            _lut[colour]++;
                        }
                    }
                        
                }
            });
        }

        public void Quantise(SKBitmap image)
        {
            Console.WriteLine("quantising the skbitmap");
            for(int x = 0; x < image.Height; x++){
                for(int y = 0; y < image.Width; y++){
                    ColourType colour = image.GetPixel(x, y).ToUint32();
                    //Console.WriteLine($"{colour:X8}");
                    if (!_lut.ContainsKey(colour))
                    {
                        _lut[colour] = 0; ;
                    }
                    else
                    {
                        _lut[colour]++;
                    }
                }
            }
        }

        public  HashSet<ColourType> GetColours()
        {
            HashSet<ColourType> colorset = new(_lut.Keys);
            return colorset;
        }

        public void PrintColours()
        {
            var keys = _lut.Keys;
            foreach (var key in keys)
            {
                Console.WriteLine($"{key:X8} - count: {_lut[key]}");
            }
        }

        public void GetMax()
        {
            Console.WriteLine($"{_lut.Max(element => element.Key):X8}");
        }
    }

}