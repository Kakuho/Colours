// Implementation of a Octree Data Structure
// This Octree is implemented assuming colours (24 bit integers) are stored

using System.Numerics;

namespace Colours.Library.DataStructures{
    class OctreeNode<T> where T : IBitwiseOperators<T, int, byte>, new()
    {
        OctreeNode(){
            ReferenceCount = 0;
            Children = new OctreeNode<T>[8];
            Value = new();
        }

        OctreeNode(T value){
            ReferenceCount = 0;
            Children = new OctreeNode<T>[8];
            Value = value;
        }

        OctreeNode(OctreeNode<T> parent){
            ReferenceCount = 0;
            Parent = parent;
            Children = new OctreeNode<T>[8];
            Value = new();
        }

        uint GetBranch(T value){
            byte index1 = value & 0x80;
            byte index2 = value & 0x20;
            byte index3 = value & 0x08;
            uint finalIndex = index1;
            finalIndex <<= 1;
            finalIndex |= index2;
            finalIndex <<= 1;
            finalIndex |= index3;
            return finalIndex;
        }

        void AddChildren(T value){
            Children[GetBranch(value)] = new(value){Parent = this};
        }

        uint ReferenceCount{get; set;}
        public OctreeNode<T> Parent{get; set;} = null!;
        public OctreeNode<T>[] Children{get; set;} = null!;
        T Value{get; set;}
    }
}