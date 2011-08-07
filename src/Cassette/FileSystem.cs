﻿using System.IO;

namespace Cassette
{
    public class FileSystem : IFileSystem
    {
        public FileSystem(string rootDirectory)
        {
            this.rootDirectory = rootDirectory;
        }

        readonly string rootDirectory;

        public Stream OpenRead(string filename)
        {
            return File.OpenRead(GetFullPath(filename));
        }

        public Stream OpenWrite(string filename)
        {
            return File.Open(GetFullPath(filename), FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public bool FileExists(string filename)
        {
            return File.Exists(GetFullPath(filename));
        }

        public void DeleteAll()
        {
            foreach (var directory in Directory.GetDirectories(rootDirectory))
            {
                Directory.Delete(directory, true);
            }
            foreach (var filename in Directory.GetFiles(rootDirectory))
            {
                File.Delete(filename);
            }
        }

        string GetFullPath(string filename)
        {
            return Path.Combine(rootDirectory, filename);
        }
    }
}