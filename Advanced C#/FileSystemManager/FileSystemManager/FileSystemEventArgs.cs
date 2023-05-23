using System;

namespace FileSystemManager
{
    public class FileSystemEventArgs : EventArgs
    {
        public string Path { get; }
        public int DirectoryCount { get; set; }
        public int FileCount { get; set; }
        public bool ExcludeFromFinalList { get; set; }
        public bool AbortSearch { get; set; }

        public FileSystemEventArgs(string path)
        {
            Path = path;
            ExcludeFromFinalList = false;
            AbortSearch = false;
        }
    }
}
