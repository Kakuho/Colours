using Colours.Library;
using Colours.Library.PixelTypes;

namespace Colours.Library.Test
{
    static public class RgbaTest
    {
        [Fact]
        static public void UInt32RgbaConversions()
        {
            System.UInt32 colourint = 0x12345678;
            Rgba colourRgba = new(colourint);
            Assert.Equal(colourRgba.ToUInt32(), colourint);
        }

        [Fact]
        static public void Deconstruct()
        {
            byte r = 0x12;
            byte g = 0x34;
            byte b = 0x56;
            byte a = 0x78;
            Rgba colourRgba = new(r, g, b, a);
            var (rd, gd, bd, ad) = colourRgba;
            Assert.Equal(r, rd);
            Assert.Equal(g, gd);
            Assert.Equal(b, bd);
            Assert.Equal(a, ad);
        }
    }
}