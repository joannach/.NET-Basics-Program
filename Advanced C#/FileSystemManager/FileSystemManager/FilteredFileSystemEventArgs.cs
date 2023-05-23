namespace FileSystemManager
{
    public class FilteredFileSystemEventArgs : FileSystemEventArgs
    {
        public FilteredFileSystemEventArgs(string path) : base(path)
        {
        }
    }
}
