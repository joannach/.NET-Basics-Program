using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FileSystemManager
{
    public class FileSystemVisitor : IEnumerable<string>
    {
        private string folderPath;
        private readonly Func<string, bool> filter;

        public FileSystemVisitor(string folderPath)
        {
            this.folderPath = folderPath;
            this.filter = null;
        }

        public FileSystemVisitor(string rootFolder, Func<string, bool> filter)
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
            if (filter == null || filter(folder))
                yield return folder;

            foreach (string file in Directory.GetFiles(folder))
            {
                if (filter == null || filter(file))
                    yield return file;
            }

            foreach (string subFolder in Directory.GetDirectories(folder))
            {
                if (filter == null || filter(subFolder))
                    yield return subFolder;

                foreach (string item in TraverseFolders(subFolder))
                {
                    yield return item;
                }
            }
        }
    }
}
