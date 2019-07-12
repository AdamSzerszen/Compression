using System.Collections.Generic;
using Huffman.structures;

namespace Huffman.services
{
    public class DictionaryService : IDictionaryService
    {
        public Dictionary<char, string> CreateDictionary(string text)
        {
            var occurence = new Dictionary<char, Sign>();
            foreach (var letter in text)
                if (occurence.ContainsKey(letter))
                {
                    occurence[letter].AddOccurence();
                }
                else
                {
                    var sign = new Sign(letter);
                    occurence.Add(letter, sign);
                }

            var tree = new DictionaryTree();

            return tree.CreateDictionary(occurence);
        }
    }
}