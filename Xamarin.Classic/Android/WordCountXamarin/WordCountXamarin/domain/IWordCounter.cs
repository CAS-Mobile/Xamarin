using System.Collections.Generic;
using WordCountXamarin.data;

namespace WordCountXamarin.domain
{
    public interface IWordCounter
    {
        List<WordCount> CountWords(string text);
    }
}