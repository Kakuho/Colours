using Colours.Library;
using Colours.Library.PixelTypes;

namespace Colours.Library.Test
{
    static public class ImageFileTest
    {
        [Fact]
        static public void TupleDeconstruct()
        {
            ImageFile image = new(10, 22);
            var (height, width) = image;
            Assert.Equal(10, height);
            Assert.Equal(22, width);
        }
        
        [Fact]
        static public void CorrectlyThrowsException()
        {
            try{
                ImageFile image = new(10, 22);
                image.GetPixel(0, 23);
            } catch(ImageFileException e){
                Assert.True(e is ImageFileException);
                return;
            } catch(Exception){
                Assert.Fail("ImageFileException is not thrown");
            }
        }
    }
    
}
