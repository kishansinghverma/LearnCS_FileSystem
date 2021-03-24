using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FileExplorer 
{
    public class Directory
    {
        private string path;
      
        public Directory(string path) { SetPath(path); }

        public string GetPath()
        {
            return path;
        }

        public void SetPath(string value)
        {
            path = value;
        }
        
        public bool exists()
        {
            return System.IO.Directory.Exists(this.GetPath());
        }

        public int createDirectory()
        {
            if (this.exists())
                return 0;
            try
            {
                System.IO.Directory.CreateDirectory(this.GetPath());
                return 1;
            }
            catch(Exception e)
            {
                Trace.TraceError(e.Message);
                return -1;
            }
            
        }

        public int deleteDirectory(bool ForceDelete)
        {
            if (!this.exists())
                return 0;
            try
            {
                System.IO.Directory.Delete(this.GetPath(), ForceDelete);
                return 1;
            }
            catch(Exception e)
            {
                Trace.TraceError(e.Message);
                return -1;
            }
        }
        public int getSubdirectoriesCount()
        {
            return System.IO.Directory.GetDirectories(this.GetPath()).Length;
        }
        public int getFilesCount()
        {
            return System.IO.Directory.GetFiles(this.GetPath()).Length;
        }
        public string getInfo()
        {
            string info = "No such directory found on file system!";
            if (!this.exists())
                return info;

            info = "Current directory path: " + this.GetPath() + "\n";
            info += "Directory creation time: " + System.IO.Directory.GetCreationTime(this.GetPath()) + "\n";
            info += "Last access time: " + System.IO.Directory.GetLastAccessTime(this.GetPath()) + "\n";
            info += "Last write time: " + System.IO.Directory.GetLastWriteTime(this.GetPath()) + "\n";
            info += "No. of subdirectories: " + this.getSubdirectoriesCount() + "\n";
            info += "No. of files contained: " + this.getFilesCount() + "\n";

            return info;
        }

        public string getSubdirectories()
        {
            string containts = "No such directory found on file system!";
            if (!this.exists())
                return containts;

            string[] subdirectoryEntries = System.IO.Directory.GetDirectories(this.GetPath());
            
            containts = "This directory contains " + this.getSubdirectoriesCount() + " subdirectories\n";
            foreach(string dirName in subdirectoryEntries)
                containts += dirName + "\n";
            
            return containts;
        }

        public string getFiles()
        {
            string containts = "No such directory found on file system!";
            if (!this.exists())
                return containts;

            string[] fileEntries = System.IO.Directory.GetFiles(this.GetPath());
            containts = "\nThis directory contains " + this.getFilesCount() + " files\n";
            foreach (string fileName in fileEntries)
                containts += fileName + "\n";

            return containts;
        }

        public void attachListener()
        {
            FileWatcher watcher = new FileWatcher(this);
            watcher.attachListener();
        }

    }
}
