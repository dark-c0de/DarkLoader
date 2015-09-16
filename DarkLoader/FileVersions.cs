using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkLoader
{
    class FileVersions
    {
        public static Files NewFiles;
        public static Files OldFiles;
        public class File
        {
            public string filename { get; set; }
            public string version { get; set; }
            public string url { get; set; }
            public string checksum { get; set; }
        }
        public class Files
        {
            public List<File> FileList { get; set; }

            public Files()
            {
                FileList = new List<File>();
            }
        }
        public static File FindOldByFilename(string filename)
        {
            return OldFiles.FileList.First(file => file.filename == filename);
        }
        public static File FindNewByFilename(string filename)
        {
            return NewFiles.FileList.First(file => file.filename == filename);
        }
    }
}
