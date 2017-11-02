using System;

namespace WordCountXamarin.data
{
    public class FileHolder
    {
        public string Filename { get; }
        public int Id { get; }
        public int Size { get; }

        public FileHolder(string filename, int id, int size)
        {
            Filename = filename;
            Id = id;
            Size = size;
        }
    }
}