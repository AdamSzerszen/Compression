namespace Huffman.structures
{
    public struct Sign
    {
        public char Value { get; set; }
        public int Occurence { get; private set; }

        public Sign(char value)
        {
            Occurence = 1;
            Value = value;
        }

        public void AddOccurence()
        {
            Occurence++;
        }
    }
}