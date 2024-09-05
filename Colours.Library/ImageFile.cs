// class to represent a 2d image

using Colours.Extensions;
using Colours.Library.PixelTypes;

// third party:
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SkiaSharp;


namespace Colours.Library
{
    // sane type aliases
    using uint32 = uint;
    using count_t = ulong;

    public class ImageFileException : Exception
    {
        public ImageFileException(string message)
        {
        }
    }

    public class ImageFile : IImageFile
    {
        private Rgba[,] _buffer;

        public ImageFile(Image<Rgba32> imagefile)
        {
            int Height = imagefile.Height;
            int Width = imagefile.Width;
            _buffer = new Rgba[Height, Width];
            LoadPixelData(imagefile);
        }

        public ImageFile(SkiaSharp.SKBitmap imagefile)
        {
            int Height = imagefile.Height;
            int Width = imagefile.Width;
            _buffer = new Rgba[Height, Width];
            LoadPixelData(imagefile);
        }
        
        public ImageFile(int height, int width)
        {
            _buffer = new Rgba[height, width];
        }

        public int Height
        {
            get => _buffer.GetLength(0);
        }

        public int Width
        {
            get => _buffer.GetLength(1);
        }

        public void Deconstruct(out int height, out int width){
            height = this.Height;
            width = this.Width;
        }

        public ref Rgba GetPixel(int x, int y)
        {
            if (x > Height)
            {
                throw new ImageFileException($"{x} is greater than height ({Height})");
            }
            if (y > Width)
            {
                throw new ImageFileException($"{y} is greater than Width ({Width})");
            }
            return ref _buffer[x, y];
        }

        // the methods below here are private and only accessible from the class
    
        private void LoadPixelData(SixLabors.ImageSharp.Image<Rgba32> imagefile)
        {
            // procedure  to load the entire pixel data from SixLabours to our file
            imagefile.ProcessPixelRows(accessor =>
            {
                for (int y = 0; y < accessor.Height; y++)
                {
                    Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                    for (int x = 0; x < pixelRow.Length; x++)
                    {
                        // Get a reference to the pixel at position x
                        ref Rgba32 pixel = ref pixelRow[x];
                        Console.WriteLine($"{pixel.ToHex():8}");
                        uint32 colour = Convert.ToUInt32(pixel.ToHex(), 16);
                        GetPixel(y, x) = Rgba.Convert32ToRgba(colour);
                    }
                }
            });
        }

        private void LoadPixelData(SkiaSharp.SKBitmap imagefile)
        {
            // procedure to load the entire pixel data from a SKBitmap onto our array
            for (int x = 0; x < imagefile.Height; x++)
            {
                for (int y = 0; y < imagefile.Width; y++)
                {
                    this._buffer[x, y] = imagefile.GetPixel(x, y).ToColoursRgba();
                }
            }
        }
    }
}
        