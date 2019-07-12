using System.Collections.Generic;

namespace Huffman.structures
{
    public interface IChild
    {
        string Code { get; set; }
        bool Leaf { get; set; }
        IChild Left { get; set; }
        IChild Right { get; set; }
        Sign Sign { get; set; }
        int Occurence { get; }
        List<DictionaryNode> GetFlatList();
    }
}