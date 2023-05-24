using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerConsoleApp.Files
{
    public class FileHandler
    {
        readonly List<string> extensions = new List<string> {"wav"};
        public List<File> listAllFiles(string path)
        {
            List<File> files = new List<File>();

            foreach (string extension in extensions)
            {
                string[] listFiles = Directory.GetFiles(path, extension);
                
                for (int i = 0; i < listFiles.Length; i++)
                {
                    File file = getInfo(listFiles[i]);
                    file.path = listFiles[i];
                    files.Add(file);
                }
            }
            return files;
        }

        public File getInfo(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            File file = new File(fileInfo.Name, fileInfo.Extension);

            return file;
        }
    }
}