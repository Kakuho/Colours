// Struct Definition for a Pixel in RGBA colour space

namespace Colours.Library.PixelTypes
{

    // sane type aliases
    using uint8 = byte;
    using uint32 = uint;

    public struct Rgba
    {
        public uint8 r;
        public uint8 g;
        public uint8 b;
        public uint8 a;

        // Constructors

        public Rgba(uint8 r, uint8 g, uint8 b, uint8 a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Rgba(System.UInt32 integral)
        {
            this = Convert32ToRgba(integral);
        }

        // Conversions

        public System.UInt32 ToUInt32()
        {
            return Utilities.CreateIntegerFromComponent(this.r, this.g, this.b, this.a);
        }

        static public Rgba Convert32ToRgba(uint32 val)
        {
            uint8 r = (byte)((val & (0xFF << 24)) >> 24);
            uint8 g = (byte)((val & (0xFF << 16)) >> 16);
            uint8 b = (byte)((val & (0xFF << 8)) >> 8);
            uint8 a = (byte)(val & (0xFF));
            return new(r, g, b, a);
        }

        // Operator Overloading

        public void Deconstruct(out byte r, out byte g, out byte b, out byte a)
        {
            r = this.r;
            g = this.g;
            b = this.b;
            a = this.a;
        }
    }
}