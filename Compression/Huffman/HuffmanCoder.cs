using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Huffman.services;
using Infrastructure.interfaces;

namespace Huffman
{
    public class HuffmanCoder : IEncoder, IDecoder
    {
        private readonly IDictionaryService _dictionaryService;
        private Dictionary<char, string> _dictionary;

        public HuffmanCoder(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        public string Decode(string cipher)
        {
            if (_dictionary != null)
            {
                var fixedBits = GetFixedBitsCount(ref cipher);
                var cipherBinary = GetStringCode(cipher);
                var stringBuilder = new StringBuilder();
                var tempCode = string.Copy(cipherBinary);

                tempCode = DecodeContent(tempCode, stringBuilder);
                FixLastSign(tempCode, fixedBits, stringBuilder);

                return stringBuilder.ToString();
            }

            return string.Empty;
        }

        public string Encode(string plaintext)
        {
            _dictionary = _dictionaryService.CreateDictionary(plaintext);

            var encryptedMessageBuilder = new StringBuilder();

            foreach (var letter in plaintext)
            {
                encryptedMessageBuilder.Append(_dictionary[letter]);
                encryptedMessageBuilder.Append(" ");
            }

            encryptedMessageBuilder.Remove(encryptedMessageBuilder.Length - 1, 1);
            var processedCipher = ProcessCipherText(encryptedMessageBuilder.ToString());

            return processedCipher;
        }

        private static int GetFixedBitsCount(ref string cipher)
        {
            var fixedBits = (int) char.GetNumericValue(cipher.ElementAt(cipher.Length - 1));
            cipher = cipher.Remove(cipher.Length - 1, 1);
            return fixedBits;
        }

        private void FixLastSign(string tempCode, int fixedBits, StringBuilder stringBuilder)
        {
            if (tempCode.Length > fixedBits)
            {
                tempCode = tempCode.Remove(tempCode.Length - 1 - fixedBits, fixedBits);
                stringBuilder.Append(_dictionary.FirstOrDefault(x => x.Value == tempCode).Key);
            }
        }

        private string DecodeContent(string tempCode, StringBuilder stringBuilder)
        {
            while (tempCode.Length > 8)
            {
                var length = 0;
                string tempPart;
                do
                {
                    length++;
                    tempPart = tempCode.Substring(0, length);
                } while (!_dictionary.ContainsValue(tempPart));

                stringBuilder.Append(_dictionary.FirstOrDefault(x => x.Value == tempPart).Key);
                tempCode = tempCode.Remove(0, length);
            }

            return tempCode;
        }

        private string GetStringCode(string encryptedMessage)
        {
            var stringBuilder = new StringBuilder();

            foreach (var letter in encryptedMessage)
            {
                int letterNumber = letter;
                var letterString = Convert.ToString(letterNumber, 2);
                while (letterString.Length < 8) letterString = "0" + letterString;
                stringBuilder.Append(letterString);
            }

            return stringBuilder.ToString();
        }

        private string ProcessCipherText(string text)
        {
            var cipherValues = text.Split(' ');
            var cipherBuilder = new StringBuilder();
            var tempPart = "";
            foreach (var cipherPart in cipherValues)
            {
                var tempSum = tempPart + cipherPart;

                while (tempSum.Length >= 8)
                {
                    var partToRemove = tempSum.Substring(0, 8);
                    cipherBuilder.Append((char) Convert.ToInt32(partToRemove, 2));
                    tempSum = tempSum.Remove(0, 8);
                }

                tempPart = tempSum;
            }

            var missingBits = 8 - tempPart.Length;
            for (var i = 0; i < missingBits; i++) tempPart += "0";

            if (tempPart.Length > 0) cipherBuilder.Append((char) Convert.ToInt32(tempPart, 2));
            cipherBuilder.Append(missingBits);

            return cipherBuilder.ToString();
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