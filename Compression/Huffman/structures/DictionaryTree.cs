using System.Collections.Generic;
using System.Linq;

namespace Huffman.structures
{
    public class DictionaryTree
    {
        private List<DictionaryNode> _tree;

        public Dictionary<char, string> CreateDictionary(Dictionary<char, Sign> occurence)
        {
            var dict = new Dictionary<char, string>();
            _tree = occurence.Select(x => new DictionaryNode(x.Value)).ToList();

            BuildTree();

            var root = _tree.FirstOrDefault();
            if (root != null)
            {
                root.Code = "";
                PrepareDictionary(root, dict);
            }

            return dict;
        }

        private void PrepareDictionary(DictionaryNode root, Dictionary<char, string> dict)
        {
            var flattedTree = root.GetFlatList().ToList();
            foreach (var dictionaryNode in flattedTree) dict.Add(dictionaryNode.Sign.Value, dictionaryNode.Code);
        }

        private void BuildTree()
        {
            while (_tree.Count > 1)
            {
                var smallest = ExtractMinimalSubtree();
                var secondSmallest = ExtractMinimalSubtree();

                var subtree = new DictionaryNode {Leaf = false, Left = smallest, Right = secondSmallest};

                _tree.Add(subtree);
            }
        }

        private DictionaryNode ExtractMinimalSubtree()
        {
            var min = _tree.Min(x => ((IChild) x).Occurence);
            var smallest = _tree.FirstOrDefault(x => ((IChild) x).Occurence == min);
            _tree.Remove(smallest);
            return smallest;
        }
    }
}