using System;

namespace WordCountXamarin.data
{
    public class WordCount : IComparable<WordCount> {

        public string Word { get; }
        public int Count { get; set; }

        public WordCount(string word)
        {
            Word = word;
            Count = 0;
        }

        public void Increment()
        {
            ++Count;
        }
      
        public int CompareTo(WordCount other)
        {
            if (Count > other.Count)
            {
                return -1;
            }
            if (Count < other.Count)
            {
                return 1;
            }
            return 0;
        }
    }
}