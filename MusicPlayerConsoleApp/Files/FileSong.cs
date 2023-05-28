using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerConsoleApp.Files
{
    public class FileSong
    {
        public string name { get; set; }
        public string extension { get; set; }
        public string path { get; set; }
        public int id { get; set; }

        public FileSong(string name, string extension)
        {
            this.name = name;
            this.extension = extension;
        }
    }
}
