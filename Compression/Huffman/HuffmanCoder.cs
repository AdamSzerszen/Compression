using System.Collections.Generic;
using Infrastructure.interfaces;

namespace Huffman
{
    public class HuffmanCoder : IEncoder, IDecoder
    {
        private Dictionary<char, string> _dictionary;

        public string Decode(string cipher)
        {
            if (_dictionary != null)
            {
            }
        }

        public string Encode(string plaintext)
        {
        }

        public void LoadDictionary(Dictionary<char, string> dictionary)
        {
            _dictionary = dictionary;
        }

        public Dictionary<char, string> GetDictionary()
        {
            return _dictionary;
        }
    }
}