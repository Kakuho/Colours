// Struct Definition for a Pixel in RGBA colour space

namespace Colours.Library.PixelTypes
{

    // sane type aliases
    using uint8 = byte;
    using uint32 = uint;

    public struct Rgba : IPixelType
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }

        // Constructors

        public Rgba(byte r, byte g, byte b, byte a)
        {
            Red = r;
            Green = g;
            Blue = b;
            Alpha = a;
        }

        public Rgba(System.UInt32 integral)
        {
            this = Convert32ToRgba(integral);
        }

        // Conversions

        public System.UInt32 ToUInt32()
        {
            return Utilities.CreateIntegerFromComponent(Red, Green, Blue, Alpha);
        }

        static public implicit operator uint(Rgba val)
        {
            return val.ToUInt32();
        }

        static public Rgba Convert32ToRgba(uint32 val)
        {
            byte r = (byte)((val & (0xFF << 24)) >> 24);
            byte g = (byte)((val & (0xFF << 16)) >> 16);
            byte b = (byte)((val & (0xFF << 8)) >> 8);
            byte a = (byte)(val & (0xFF));
            return new(r, g, b, a);
        }

        // Operator Overloading

        public void Deconstruct(out byte r, out byte g, out byte b, out byte a)
        {
            r = Red;
            g = Green;
            b = Blue;
            a = Alpha;
        }

    }
}