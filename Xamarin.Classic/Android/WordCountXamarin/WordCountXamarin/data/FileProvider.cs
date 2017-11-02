using System.Collections.Generic;

namespace WordCountXamarin.data
{
    public class FileProvider
    {
        public static List<FileHolder> GetFiles()
        {
            return new List<FileHolder>()
            {
                new FileHolder("lorem.txt", Resource.Raw.lorem, 1),
                new FileHolder("rfc2396.txt", Resource.Raw.rfc2396, 83),
                new FileHolder("rfc2616.txt", Resource.Raw.rfc2616, 413)
            };
        }
    }
}