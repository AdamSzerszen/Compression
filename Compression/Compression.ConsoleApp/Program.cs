using System;
using Huffman;
using Huffman.services;

namespace Compression.ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var plainText = "ala ma kota";
            var huffman = new HuffmanCoder(new DictionaryService());

            var cipher = huffman.Encode(plainText);
            Console.WriteLine($"Encrypted: {cipher}");

            var decrypted = huffman.Decode(cipher);
            Console.WriteLine($"Decrypted: {decrypted}");
        }
    }
}