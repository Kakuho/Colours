// Struct Definition for a Pixel in HSL colour space

namespace Colours.Library.PixelTypes
{

    // sane type aliases
    using uint8 = byte;
    using uint32 = uint;

    public struct Hsla
    {
        public uint8 hue;
        public uint8 sat;
        public uint8 lumi;
        public uint8 a;
    }
}