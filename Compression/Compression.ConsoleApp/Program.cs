using Huffman;
using Huffman.services;
using Infrastructure.services;

namespace Compression.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = "testfile.txt";
            var huffman = new HuffmanCoder(new DictionaryService());
            var fileService = new FileService();
            var plainText = fileService.LoadData(path);

            var cipher = huffman.Encode(plainText);
            fileService.SaveData("cipher.txt", cipher);

            var loadedCipher = fileService.LoadData("cipher.txt");
            var decrypted = huffman.Decode(loadedCipher);
            fileService.SaveData("decoded.txt", decrypted);
        }
    }
}