using System.Collections.Generic;
using System.Linq;
using WordCountXamarin.data;

namespace WordCountXamarin.domain
{
    public class WordCounter : IWordCounter
    {

        public List<WordCount> CountWords(string text)
        {

            // Texttrennzeichen, etc ersetzen
            // Absichtlich "schlechter" Algorithmus
            text = text.Replace(".", "");
            text = text.Replace(",", "");
            text = text.Replace("\"", "");
            text = text.Replace("-", "");
            text = text.Replace("=", "");
            text = text.Replace("|", "");

            // String aufteilen und Zaehler setzen
            var hash = new Dictionary<string, WordCount>();
            var words = text.Split(null); // null splits at whitespace chars, see https://msdn.microsoft.com/en-us/library/b873y76a.aspx
            foreach (var w in words)
            {
                // keine Sonderzeichen, nur Kleinschreibung
                var word = w.Trim().ToLower();
                if (word.Length == 0)
                {
                    continue;
                }

                if (!hash.ContainsKey(word))
                {
                    hash.Add(word, new WordCount(word));
                }
                hash[word].Increment();
            }

            var counters = hash.Values;

            // Zaehler sortieren und nur 20 hoechste Zaehler als Resultat
            // ... with Linq a piece of cake!! :-)
            var result = counters
                .OrderByDescending(x => x.Count)
                .Take(20)
                .ToList();

            return result;
        }
    }
}