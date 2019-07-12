using System.Collections.Generic;

namespace Huffman.structures
{
    public interface IChild
    {
        string Code { get; set; }
        bool Leaf { get; set; }
        IChild Left { get; set; }
        IChild Right { get; set; }

        int Occurence();

        Sign GetSign();

        void SetCode(string code);
        List<DictionaryNode> GetFlatList();
    }
}