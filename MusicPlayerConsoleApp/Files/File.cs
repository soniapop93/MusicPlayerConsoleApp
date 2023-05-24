using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerConsoleApp.Files
{
    public class File
    {
        public string name { get; set; }
        public string extension { get; set; }
        public string path { get; set; }

        public File(string name, string extension)
        {
            this.name = name;
            this.extension = extension;
        }
    }
}
