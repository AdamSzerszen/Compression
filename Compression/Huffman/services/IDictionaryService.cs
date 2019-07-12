using System.Collections.Generic;

namespace Huffman.services
{
    public interface IDictionaryService
    {
        Dictionary<char, string> CreateDictionary(string text);
    }
}