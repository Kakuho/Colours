// Implementation of a Octree Node, implemented assuming colours (32 bit unsigned integers) are stored

using System.Numerics;
using Colours.Library.PixelTypes;

namespace Colours.Library.DataStructures
{
    public class OctreeNode
    {
        private const byte _branches = 8;
        public uint ReferenceCount { get; set; }
        public OctreeNode Parent { get; set; } = null!;
        public OctreeNode[] Children { get; set; } = null!;
        public Rgba Value { get; set; }

        public byte Red
        {
            get { return Value.Red; }
        }

        public byte Green
        {
            get { return Value.Green; }
        }

        public byte Blue
        {
            get { return Value.Blue; }
        }

        //---------------------------------------------------------
        // Lifetime
        //---------------------------------------------------------

        public OctreeNode()
        {
            ReferenceCount = 0;
            Children = new OctreeNode[_branches];
            Value = default!;
        }

        public OctreeNode(Rgba value)
        {
            ReferenceCount = 0;
            Children = new OctreeNode[_branches];
            Value = value;
        }

        public OctreeNode(uint value)
        {
            ReferenceCount = 0;
            Children = new OctreeNode[_branches];
            Value = Rgba.Convert32ToRgba(value);
        }

        public OctreeNode(OctreeNode parent)
        {
            ReferenceCount = 0;
            Parent = parent;
            Children = new OctreeNode[_branches];
            Value = default!;
        }

        //---------------------------------------------------------
        // Operational 
        //---------------------------------------------------------

        public uint GetBranch(Rgba value, uint depth)
        {
            if (depth > 7)
            {
                throw new Exception();
            }
            byte bfactor = (byte)(7 - depth);
            // -0xf0. bfactor = 3
            // 1 << 3 = 0b1000
            byte index1 = (byte)((value.Red & (1 << bfactor)) >> bfactor);
            byte index2 = (byte)((value.Blue & (1 << bfactor)) >> bfactor);
            byte index3 = (byte)((value.Green & (1 << bfactor)) >> bfactor);
            uint finalIndex = index1;
            finalIndex <<= 1;
            finalIndex |= index2;
            finalIndex <<= 1;
            finalIndex |= index3;
            return finalIndex;
        }

        public void AddChildren(Rgba value, uint depth)
        {
            Children[GetBranch(value, depth)] = new(value) { Parent = this };
        }

        public void AddChildren(OctreeNode node, uint depth)
        {
            Children[GetBranch(node.Value, depth)] = node;
        }

    }
}