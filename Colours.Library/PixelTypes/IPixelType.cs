// Interface for Pixel Types
// It may not be a good idea for structs to implement interfaces if it performs boxing...
// A struct calling a interface member implementation does not perform boxing
// A variable with type of the interface will perform boxing

namespace Colours.Library.PixelTypes
{
    public interface IPixelType
    {
        public System.UInt32 ToUInt32();
        public void Deconstruct(out byte first, out byte second, out byte third, out byte fourth);
    }
}