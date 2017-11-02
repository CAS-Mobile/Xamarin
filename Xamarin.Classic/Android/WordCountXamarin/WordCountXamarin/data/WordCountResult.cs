using System;
using System.Collections.Generic;

namespace WordCountXamarin.data
{
    [Serializable]
    public class WordCountResult 
    {
        public FileHolder FileHolder { get; set; }
        public List<WordCount> Counters { get; }

        public WordCountResult(FileHolder fileHolder, List<WordCount> counters)
        {
            FileHolder = fileHolder;
            Counters = counters;
        }
    }
}