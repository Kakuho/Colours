using Colours.Library.DataStructures;
using Colours.Library.Quantisers;
using Colours.Library.PixelTypes;

namespace Colours.Library.Test
{

    static public class OctreeNodeTest
    {

        [Fact]
        static public void CorrectRGBProperties1()
        {
            // first node
            OctreeNode val = new(0x12345678);
            Console.WriteLine(val.Red);
            Assert.Equal(0x12, val.Red);
            Assert.Equal(0x34, val.Green);
            Assert.Equal(0x56, val.Blue);
        }

        [Fact]
        static public void CorrectRGBProperties2()
        {
            OctreeNode val = new(0xabcdef12);
            Assert.Equal(0xab, val.Red);
            Assert.Equal(0xcd, val.Green);
            Assert.Equal(0xef, val.Blue);
        }

        [Fact]
        static public void CorrectRGBProperties3()
        {
            OctreeNode val = new(0xf0f0f000);
            Assert.Equal(0xf0, val.Red);
            Assert.Equal(0xf0, val.Green);
            Assert.Equal(0xf0, val.Blue);
        }

        [Fact]
        static public void BranchingIndexCorrect0xF0F0F000()
        {
            OctreeNode node = new();
            Rgba value = new Rgba(0xF0F0F000);
            Assert.Equal(0b111u, node.GetBranch(value, 0), 0b111u);
            Assert.Equal(0b111u, node.GetBranch(value, 1), 0b111u);
            Assert.Equal(0b111u, node.GetBranch(value, 2), 0b111u);
            Assert.Equal(0b111u, node.GetBranch(value, 3), 0b111u);
            // second nibble
            Assert.Equal(0b000u, node.GetBranch(value, 4), 0b000u);
            Assert.Equal(0b000u, node.GetBranch(value, 5), 0b000u);
        }

        [Fact]
        static public void BranchingIndexCorrect0x12345600()
        {
            OctreeNode node = new();
            Rgba value = new Rgba(0x12_34_56_00);
            // also equals to 0b0001_0010_ _0011_0100_ _0101_0110_
            Assert.Equal(0b100u, node.GetBranch(value, 0), 0b100u);
            Assert.Equal(0b001u, node.GetBranch(value, 1), 0b001u);
            Assert.Equal(0b010u, node.GetBranch(value, 2), 0b010u);
            Assert.Equal(0b111u, node.GetBranch(value, 3), 0b111u);
            // second nibble
            Assert.Equal(0b000u, node.GetBranch(value, 4), 0b000u);
            Assert.Equal(0b011u, node.GetBranch(value, 5), 0b011u);
            Assert.Equal(0b101u, node.GetBranch(value, 6), 0b101u);
            Assert.Equal(0b000u, node.GetBranch(value, 7), 0b000u);
        }

    };
}