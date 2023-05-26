namespace MusicPlayerConsoleApp.Files
{
    public class FileHandler
    {
        readonly List<string> extensions = new List<string> {"*.wav"};
        public List<FileSong> listAllFiles(string path)
        {
            List<FileSong> files = new List<FileSong>();

            foreach (string extension in extensions)
            {
                string[] listFiles = Directory.GetFiles(path, extension);
                
                for (int i = 0; i < listFiles.Length; i++)
                {
                    FileSong file = getInfo(listFiles[i]);
                    file.path = listFiles[i];
                    files.Add(file);
                }
            }
            return files;
        }

        private FileSong getInfo(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            FileSong file = new FileSong(fileInfo.Name, fileInfo.Extension);

            return file;
        }

        public void displayAllSongs(List<FileSong> files)
        {
            if (files.Count > 0)
            {
                Console.WriteLine("-------------- Songs available --------------");
                for (int i = 0; i < files.Count; i++)
                {
                    Console.WriteLine(files[i].name);
                }
            }
            else
            {
                Console.WriteLine("No songs available");
            }
        }
    }
}