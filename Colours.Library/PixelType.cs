// Definitions structures representing points of color spaces

namespace Colours.Library
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

        public Rgba(uint8 r, uint8 g, uint8 b, uint8 a){
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public System.UInt32 ToUInt32(){
            return Utilities.CreateIntegerFromComponent(this.r, this.g, this.b, this.a);
        }

        static public Rgba Convert32ToRgba(uint32 val){
            uint8 r = (byte)(val & (0xFF << 24));
            uint8 g = (byte)(val & (0xFF << 16));
            uint8 b = (byte)(val & (0xFF << 8));
            uint8 a = (byte)(val & (0xFF));
            return new(r, g, b, a); 
        }
    }

    struct Hsl
    {
        uint8 hue;
        uint8 sat;
        uint8 light;
    }

}