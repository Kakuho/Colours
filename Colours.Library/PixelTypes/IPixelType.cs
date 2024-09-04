// Interface for Pixel Types
// It may not be a good idea for structs to implement interfaces if it performs boxing...

namespace Colours.Library.PixelTypes
{
    public interface IPixelType
    {
        public System.UInt32 ToUInt32();
        public void Deconstruct(out byte first, out byte second, out byte third, out byte fourth);
    }
}