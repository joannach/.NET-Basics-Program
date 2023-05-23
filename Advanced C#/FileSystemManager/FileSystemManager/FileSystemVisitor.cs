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

            //if (ShouldExcludeItem(folder))
            //    yield break;

            if (filter == null || filter(folder))
            {
                OnDirectoryFound(new FileSystemEventArgs(folder));
                yield return folder;
            }

            foreach (string file in Directory.GetFiles(folder))
            {
                if (filter == null || filter(file))
                {
                    var args = new FileSystemEventArgs(file);
                    OnFileFound(args);

                    if (args.AbortSearch)
                        yield break;

                    yield return file;
                }
            }

            foreach (string subFolder in Directory.GetDirectories(folder))
            {
                if (filter == null || filter(subFolder))
                {
                    var args = new FileSystemEventArgs(subFolder);
                    OnDirectoryFound(args);
                    if (args.AbortSearch)
                        yield break;

                    yield return subFolder;
                }

                foreach (string item in TraverseFolders(subFolder))
                {
                    if (filter == null || filter(item))
                    {
                        var args = new FileSystemEventArgs(item);
                        OnFileFound(args);
                        if (args.AbortSearch)
                            yield break;

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

        private void OnFileFound(FileSystemEventArgs e)
        {
            FileFound?.Invoke(this, e);
        }

        private void OnDirectoryFound(FileSystemEventArgs e)
        {
            DirectoryFound?.Invoke(this, e);
        }

        private void OnFilteredFileFound(FilteredFileSystemEventArgs e)
        {
            FilteredFileFound?.Invoke(this, e);
            //exclude = exclude || /* Your logic for excluding the file */;
        }

        private void OnFilteredDirectoryFound(FilteredFileSystemEventArgs e)
        {
            FilteredDirectoryFound?.Invoke(this, e);
            //exclude = exclude || /* Your logic for excluding the directory */;
        }
    }
}
