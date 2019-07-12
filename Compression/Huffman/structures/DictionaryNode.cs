using System.Collections.Generic;

namespace Huffman.structures
{
    public class DictionaryNode : IChild
    {
        public DictionaryNode()
        {
            Leaf = false;
        }

        public DictionaryNode(Sign sign)
        {
            Leaf = true;
            Sign = sign;
        }

        public IChild Right { get; set; }
        public Sign Sign { get; set; }

        public IChild Left { get; set; }

        public int Occurence()
        {
            var occurrence = 0;
            if (Left != null) occurrence += Left.Occurence();

            if (Right != null) occurrence += Right.Occurence();

            if (Leaf) occurrence += Sign.Occurence;

            return occurrence;
        }

        public string Code { get; set; }
        public bool Leaf { get; set; }

        public void SetCode(string code)
        {
            Code = code;

            if (!Leaf)
            {
                Left.SetCode(code + "0");
                Right.SetCode(code + "1");
            }
        }

        public List<DictionaryNode> GetFlatList()
        {
            if (Leaf)
                return new List<DictionaryNode>
                {
                    this
                };

            var left = Left.GetFlatList();
            var right = Right.GetFlatList();

            left.AddRange(right);
            return left;
        }
    }
}