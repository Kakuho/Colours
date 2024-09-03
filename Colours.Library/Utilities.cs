// Global Utility Methods

namespace Colours.Library
{

    static class Utilities
    {
        public static System.UInt32 CreateIntegerFromComponent(byte red, byte green, byte blue, byte alpha){
            System.UInt32 integral = red;
            integral <<= 8;
            integral |= green;
            integral <<= 8;
            integral |= blue;
            integral <<= 8;
            integral |= alpha;
            return integral; 
        }

        public static void RgbToHsl(Rgba src)
        {

        }

        public static void HslToRgba(Hsl src)
        {

        }

    }

}