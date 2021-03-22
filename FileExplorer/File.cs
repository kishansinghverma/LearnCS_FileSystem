using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FileExplorer
{
    class File
    {
        private string Path;

        public File(string path)
        {
            Path = path;
        }

        public int copy(string targetDir)
        {
            string[] tokens = this.Path.Split(new char[] {'/', '\\'});
            string fileName = tokens.Last();

            Directory backupDir = new Directory(targetDir);
            if (!backupDir.exists())
                backupDir.createDirectory();

            try
            {
                System.IO.File.Copy(this.Path, targetDir + "/" + fileName, true);
                return 1;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.Message);
                return -1;
            }
        }
    }
}
