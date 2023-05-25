using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FileSystemManager
{
    public class FileSystemVisitor : IEnumerable<string>
    {
        public string folderPath;
        public Func<string, bool> filter;

        public event EventHandler Start;
        public event EventHandler Finish;
        public event EventHandler<FileSystemEventArgs> FileFound;
        public event EventHandler<FileSystemEventArgs> DirectoryFound;
        public event EventHandler<FilteredFileSystemEventArgs> FilteredFileFound;
        public event EventHandler<FilteredFileSystemEventArgs> FilteredDirectoryFound;


        public FileSystemVisitor(string rootFolder, Func<string, bool> filter = null)
        {
            this.folderPath = rootFolder;
            this.filter = filter;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return TraverseFolders(folderPath).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<string> TraverseFolders(string folder)
        {
            OnStart();

            if (ShouldAbortSearch())
                yield break;

            if (filter == null || filter(folder))
            {
                var args = new FileSystemEventArgs(folder);
                OnDirectoryFound(args);

                if (args.AbortSearch)
                    yield break;

                if (!args.ExcludeFromFinalList)
                    yield return folder;
            }

            foreach (string file in Directory.GetFiles(folder))
            {
                if (ShouldAbortSearch())
                    yield break;

                if (filter == null || filter(file))
                {
                    var args = new FileSystemEventArgs(file);
                    OnFileFound(args);

                    if (args.AbortSearch)
                        yield break;

                    if (!args.ExcludeFromFinalList)
                        yield return file;
                }
            }

            foreach (string subFolder in Directory.GetDirectories(folder))
            {
                if (ShouldAbortSearch())
                    yield break;

                if (filter == null || filter(subFolder))
                {
                    var args = new FileSystemEventArgs(subFolder);
                    OnDirectoryFound(args);

                    if (args.AbortSearch)
                        yield break;

                    if (!args.ExcludeFromFinalList)
                        yield return subFolder;
                }

                foreach (string item in TraverseFolders(subFolder))
                {
                    if (ShouldAbortSearch())
                        yield break;

                    if (filter == null || filter(item))
                    {
                        var args = new FileSystemEventArgs(item);
                        OnFileFound(args);

                        if (args.AbortSearch)
                            yield break;

                        if (!args.ExcludeFromFinalList)
                            yield return item;
                    }
                }
            }

            OnFinish();
        }

        protected virtual void OnStart()
        {
            Start?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnFinish()
        {
            Finish?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnFileFound(FileSystemEventArgs e)
        {
            FileFound?.Invoke(this, e);
        }

        protected virtual void OnDirectoryFound(FileSystemEventArgs e)
        {
            DirectoryFound?.Invoke(this, e);
        }

        protected virtual void OnFilteredFileFound(FilteredFileSystemEventArgs e)
        {
            FilteredFileFound?.Invoke(this, e);
        }

        protected virtual void OnFilteredDirectoryFound(FilteredFileSystemEventArgs e)
        {
            FilteredDirectoryFound?.Invoke(this, e);
        }

        private bool ShouldExcludeItem(string path)
        {
            var args = new FileSystemEventArgs(path);
            OnFilteredFileFound(new FilteredFileSystemEventArgs(path));

            if (args.ExcludeFromFinalList)
                return true;

            return false;
        }

        private bool ShouldAbortSearch()
        {
            var args = new FileSystemEventArgs(null);
            OnFinish();

            return args.AbortSearch;
        }
    }
}
